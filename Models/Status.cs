using ResponseState.Enums;
using System.Reflection;

namespace ResponseState.Models;

public class Status
{
    private static readonly Dictionary<(int Code, double SubCode), string> _stateCodeNameCache = new();
    private static readonly object _cacheLock = new();
    private static bool _cacheInitialized = false;

    public int Code { get; set; }
    public double SubCode { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
    public bool Success { get; set; }
    public string Level { get; set; } = string.Empty;

    // Static constructor: Uygulama başlarken cache'i doldur
    static Status()
    {
        InitializeCache();
    }

    public Status()
    {
        Code = StateCode.OK.Code;
        SubCode = StateCode.OK.SubCode;
        Name = GetStateCodeName(StateCode.OK);
        Message = StateCode.OK.Message;
        Success = StateCode.OK.Success;
        Level = MessageLevel.Success.ToString().ToLower();
    }

    public Status(StateCode code)
    {
        Code = code.Code;
        SubCode = code.SubCode;
        Name = GetStateCodeName(code);
        Message = code.Message;
        Success = code.Success;
        Level = code.Level.ToString().ToLower();
    }

    public Status(StateCode code, string? overrideMessage)
    {
        Code = code.Code;
        SubCode = code.SubCode;
        Name = GetStateCodeName(code);
        Message = overrideMessage ?? code.Message;
        Success = code.Success;
        Level = code.Level.ToString().ToLower();
    }

    public Status(StateCode code, params object[] messageArgs)
    {
        Code = code.Code;
        SubCode = code.SubCode;
        Name = GetStateCodeName(code);
        try
        {
            Message = string.Format(code.Message, messageArgs);
        }
        catch (FormatException)
        {
            Message = code.Message;
        }
        Success = code.Success;
        Level = code.Level.ToString().ToLower();
    }

    public Status(int code, string message, bool isSuccess = true, string? level = null)
    {
        Code = 220 + code;
        SubCode = 0;
        Name = $"CustomCode_{code}";
        Message = message;
        Success = isSuccess;
        Level = level ?? MessageLevel.Success.ToString().ToLower();
    }

    /// <summary>
    /// Uygulama başlangıcında tüm StateCode field'larını cache'e al
    /// </summary>
    private static void InitializeCache()
    {
        if (_cacheInitialized)
            return;

        lock (_cacheLock)
        {
            if (_cacheInitialized)
                return;

            try
            {
                // StateCode sınıfındaki tüm static field'ları bul
                var stateCodeFields = typeof(StateCode).GetFields(BindingFlags.Public | BindingFlags.Static)
                    .Where(f => f.FieldType == typeof(StateCode));

                foreach (var field in stateCodeFields)
                {
                    var value = field.GetValue(null) as StateCode;
                    if (value != null)
                    {
                        var key = (value.Code, value.SubCode);
                        _stateCodeNameCache[key] = field.Name;
                    }
                }

                // ApplicationStateCode (varsa) - Reflection ile otomatik bul
                var assemblies = AppDomain.CurrentDomain.GetAssemblies();
                foreach (var assembly in assemblies)
                {
                    try
                    {
                        var types = assembly.GetTypes()
                            .Where(t => t.IsClass && !t.IsAbstract && t.IsSubclassOf(typeof(StateCode)));

                        foreach (var type in types)
                        {
                            var fields = type.GetFields(BindingFlags.Public | BindingFlags.Static)
                                .Where(f => f.FieldType == typeof(StateCode));

                            foreach (var field in fields)
                            {
                                var value = field.GetValue(null) as StateCode;
                                if (value != null)
                                {
                                    var key = (value.Code, value.SubCode);
                                    // Önce gelene öncelik (StateCode override eder ApplicationStateCode'u)
                                    if (!_stateCodeNameCache.ContainsKey(key))
                                    {
                                        _stateCodeNameCache[key] = field.Name;
                                    }
                                }
                            }
                        }
                    }
                    catch
                    {
                        // Assembly yüklenemezse devam et
                    }
                }

                _cacheInitialized = true;
            }
            catch
            {
                // Cache başlatılamazsa runtime'da dolacak
            }
        }
    }

    /// <summary>
    /// Cache'den StateCode field adını döndürür
    /// </summary>
    private static string GetStateCodeName(StateCode code)
    {
        var key = (code.Code, code.SubCode);

        // Cache'de var mı kontrol et
        if (_stateCodeNameCache.TryGetValue(key, out var cachedName))
            return cachedName;

        // Cache'de yoksa (olmaması lazım ama yine de)
        lock (_cacheLock)
        {
            // Double-check locking
            if (_stateCodeNameCache.TryGetValue(key, out cachedName))
                return cachedName;

            // Runtime'da reflection ile bul
            var fields = typeof(StateCode).GetFields(BindingFlags.Public | BindingFlags.Static);

            foreach (var field in fields)
            {
                if (field.FieldType == typeof(StateCode))
                {
                    var value = field.GetValue(null) as StateCode;
                    if (value != null && value.Code == code.Code && value.SubCode == code.SubCode)
                    {
                        _stateCodeNameCache[key] = field.Name;
                        return field.Name;
                    }
                }
            }

            // Fallback
            var fallbackName = "UnknownStateCode";
            _stateCodeNameCache[key] = fallbackName;
            return fallbackName;
        }
    }
}