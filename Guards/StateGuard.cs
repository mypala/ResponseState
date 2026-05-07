using ResponseState.Enums;
using ResponseState.Exceptions;
using ResponseState.Models;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace ResponseState.Guards;

/// <summary>
/// StateException tabanlı validation guard metodları
/// </summary>
public static class StateGuard
{
    #region ThrowIfNull - Default ve Custom StateCode

    /// <summary>
    /// Argüman null ise StateException fırlatır (Default: NullParameterError)
    /// </summary>
    /// <param name="argument">Kontrol edilecek argüman</param>
    /// <param name="paramName">Parametre adı (otomatik doldurulur)</param>
    /// <exception cref="StateException">Argüman null ise fırlatılır</exception>
    public static void ThrowIfNull([NotNull] object? argument, [CallerArgumentExpression(nameof(argument))] string? paramName = null)
    {
        ThrowIfNull(argument, StateCode.NullParameterError, paramName);
    }

    /// <summary>
    /// Argüman null ise StateException fırlatır (Custom StateCode)
    /// </summary>
    /// <param name="argument">Kontrol edilecek argüman</param>
    /// <param name="stateCode">Fırlatılacak StateCode</param>
    /// <param name="paramName">Parametre adı (otomatik doldurulur)</param>
    /// <exception cref="StateException">Argüman null ise fırlatılır</exception>
    public static void ThrowIfNull([NotNull] object? argument, StateCode stateCode, [CallerArgumentExpression(nameof(argument))] string? paramName = null)
    {
        if (argument is null)
        {
            var message = string.IsNullOrEmpty(paramName)
                ? stateCode.Message
                : $"{stateCode.Message} (Parametre: {paramName})";

            throw new StateException(stateCode, message);
        }
    }

    #endregion

    #region ThrowIfNullOrEmpty (String) - Default ve Custom StateCode

    /// <summary>
    /// Argüman null veya boş string ise StateException fırlatır (Default: NullParameterError)
    /// </summary>
    /// <param name="argument">Kontrol edilecek string argüman</param>
    /// <param name="paramName">Parametre adı (otomatik doldurulur)</param>
    /// <exception cref="StateException">Argüman null veya boş ise fırlatılır</exception>
    public static void ThrowIfNullOrEmpty([NotNull] string? argument, [CallerArgumentExpression(nameof(argument))] string? paramName = null)
    {
        ThrowIfNullOrEmpty(argument, StateCode.NullParameterError, paramName);
    }

    /// <summary>
    /// Argüman null veya boş string ise StateException fırlatır (Custom StateCode)
    /// </summary>
    /// <param name="argument">Kontrol edilecek string argüman</param>
    /// <param name="stateCode">Fırlatılacak StateCode</param>
    /// <param name="paramName">Parametre adı (otomatik doldurulur)</param>
    /// <exception cref="StateException">Argüman null veya boş ise fırlatılır</exception>
    public static void ThrowIfNullOrEmpty([NotNull] string? argument, StateCode stateCode, [CallerArgumentExpression(nameof(argument))] string? paramName = null)
    {
        if (string.IsNullOrEmpty(argument))
        {
            var message = string.IsNullOrEmpty(paramName)
                ? stateCode.Message
                : $"{stateCode.Message} (Parametre: {paramName})";

            throw new StateException(stateCode, message);
        }
    }

    #endregion

    #region ThrowIfNullOrWhiteSpace - Default ve Custom StateCode

    /// <summary>
    /// Argüman null, boş veya whitespace ise StateException fırlatır (Default: NullParameterError)
    /// </summary>
    /// <param name="argument">Kontrol edilecek string argüman</param>
    /// <param name="paramName">Parametre adı (otomatik doldurulur)</param>
    /// <exception cref="StateException">Argüman null, boş veya whitespace ise fırlatılır</exception>
    public static void ThrowIfNullOrWhiteSpace([NotNull] string? argument, [CallerArgumentExpression(nameof(argument))] string? paramName = null)
    {
        ThrowIfNullOrWhiteSpace(argument, StateCode.NullParameterError, paramName);
    }

    /// <summary>
    /// Argüman null, boş veya whitespace ise StateException fırlatır (Custom StateCode)
    /// </summary>
    /// <param name="argument">Kontrol edilecek string argüman</param>
    /// <param name="stateCode">Fırlatılacak StateCode</param>
    /// <param name="paramName">Parametre adı (otomatik doldurulur)</param>
    /// <exception cref="StateException">Argüman null, boş veya whitespace ise fırlatılır</exception>
    public static void ThrowIfNullOrWhiteSpace([NotNull] string? argument, StateCode stateCode, [CallerArgumentExpression(nameof(argument))] string? paramName = null)
    {
        if (string.IsNullOrWhiteSpace(argument))
        {
            var message = string.IsNullOrEmpty(paramName)
                ? stateCode.Message
                : $"{stateCode.Message} (Parametre: {paramName})";

            throw new StateException(stateCode, message);
        }
    }

    #endregion

    #region ThrowIfNullOrEmpty (Collection) - Default ve Custom StateCode

    /// <summary>
    /// Collection null veya boş ise StateException fırlatır (Default: NullParameterError)
    /// </summary>
    /// <param name="collection">Kontrol edilecek collection</param>
    /// <param name="paramName">Parametre adı (otomatik doldurulur)</param>
    /// <exception cref="StateException">Collection null veya boş ise fırlatılır</exception>
    public static void ThrowIfNullOrEmpty<T>([NotNull] IEnumerable<T>? collection, [CallerArgumentExpression(nameof(collection))] string? paramName = null)
    {
        ThrowIfNullOrEmpty(collection, StateCode.NullParameterError, paramName);
    }

    /// <summary>
    /// Collection null veya boş ise StateException fırlatır (Custom StateCode)
    /// </summary>
    /// <param name="collection">Kontrol edilecek collection</param>
    /// <param name="stateCode">Fırlatılacak StateCode</param>
    /// <param name="paramName">Parametre adı (otomatik doldurulur)</param>
    /// <exception cref="StateException">Collection null veya boş ise fırlatılır</exception>
    public static void ThrowIfNullOrEmpty<T>([NotNull] IEnumerable<T>? collection, StateCode stateCode, [CallerArgumentExpression(nameof(collection))] string? paramName = null)
    {
        if (collection is null || !collection.Any())
        {
            var message = string.IsNullOrEmpty(paramName)
                ? stateCode.Message
                : $"{stateCode.Message} (Parametre: {paramName})";

            throw new StateException(stateCode, message);
        }
    }

    #endregion

    #region ThrowIfTrue - Default ve Custom StateCode

    /// <summary>
    /// Condition true ise StateException fırlatır (Default: InvalidParameterError)
    /// </summary>
    /// <param name="condition">Kontrol edilecek koşul</param>
    /// <param name="message">Özel hata mesajı (opsiyonel)</param>
    /// <exception cref="StateException">Condition true ise fırlatılır</exception>
    public static void ThrowIfTrue([DoesNotReturnIf(true)] bool condition, string? message = null)
    {
        ThrowIfTrue(condition, StateCode.InvalidParameterError, message);
    }

    /// <summary>
    /// Condition true ise StateException fırlatır (Custom StateCode)
    /// </summary>
    /// <param name="condition">Kontrol edilecek koşul</param>
    /// <param name="stateCode">Fırlatılacak StateCode</param>
    /// <param name="message">Özel hata mesajı (opsiyonel)</param>
    /// <exception cref="StateException">Condition true ise fırlatılır</exception>
    public static void ThrowIfTrue([DoesNotReturnIf(true)] bool condition, StateCode stateCode, string? message = null)
    {
        if (condition)
        {
            throw new StateException(stateCode, message ?? stateCode.Message);
        }
    }

    #endregion

    #region ThrowIfFalse - Default ve Custom StateCode

    /// <summary>
    /// Condition false ise StateException fırlatır (Default: InvalidParameterError)
    /// </summary>
    /// <param name="condition">Kontrol edilecek koşul</param>
    /// <param name="message">Özel hata mesajı (opsiyonel)</param>
    /// <exception cref="StateException">Condition false ise fırlatılır</exception>
    public static void ThrowIfFalse([DoesNotReturnIf(false)] bool condition, string? message = null)
    {
        ThrowIfFalse(condition, StateCode.InvalidParameterError, message);
    }

    /// <summary>
    /// Condition false ise StateException fırlatır (Custom StateCode)
    /// </summary>
    /// <param name="condition">Kontrol edilecek koşul</param>
    /// <param name="stateCode">Fırlatılacak StateCode</param>
    /// <param name="message">Özel hata mesajı (opsiyonel)</param>
    /// <exception cref="StateException">Condition false ise fırlatılır</exception>
    public static void ThrowIfFalse([DoesNotReturnIf(false)] bool condition, StateCode stateCode, string? message = null)
    {
        if (!condition)
        {
            throw new StateException(stateCode, message ?? stateCode.Message);
        }
    }

    #endregion

    #region ThrowIfOutOfRange - Default ve Custom StateCode

    /// <summary>
    /// Value belirtilen aralıkta değilse StateException fırlatır (Default: InvalidParameterError)
    /// </summary>
    /// <param name="value">Kontrol edilecek değer</param>
    /// <param name="min">Minimum değer (inclusive)</param>
    /// <param name="max">Maximum değer (inclusive)</param>
    /// <param name="paramName">Parametre adı (otomatik doldurulur)</param>
    /// <exception cref="StateException">Value aralık dışındaysa fırlatılır</exception>
    public static void ThrowIfOutOfRange<T>(T value, T min, T max, [CallerArgumentExpression(nameof(value))] string? paramName = null) where T : IComparable<T>
    {
        ThrowIfOutOfRange(value, min, max, StateCode.InvalidParameterError, paramName);
    }

    /// <summary>
    /// Value belirtilen aralıkta değilse StateException fırlatır (Custom StateCode)
    /// </summary>
    /// <param name="value">Kontrol edilecek değer</param>
    /// <param name="min">Minimum değer (inclusive)</param>
    /// <param name="max">Maximum değer (inclusive)</param>
    /// <param name="stateCode">Fırlatılacak StateCode</param>
    /// <param name="paramName">Parametre adı (otomatik doldurulur)</param>
    /// <exception cref="StateException">Value aralık dışındaysa fırlatılır</exception>
    public static void ThrowIfOutOfRange<T>(T value, T min, T max, StateCode stateCode, [CallerArgumentExpression(nameof(value))] string? paramName = null) where T : IComparable<T>
    {
        if (value.CompareTo(min) < 0 || value.CompareTo(max) > 0)
        {
            var message = string.IsNullOrEmpty(paramName)
                ? $"{stateCode.Message} (Geçerli aralık: {min} - {max})"
                : $"{stateCode.Message} (Parametre: {paramName}, Geçerli aralık: {min} - {max})";

            throw new StateException(stateCode, message);
        }
    }

    #endregion

    #region ResponseState<bool> & ResponseState<bool?> - ThrowIfTrue & ThrowIfFalse

    // ========== ResponseState<bool> - Non-nullable ==========

    /// <summary>
    /// ResponseState<bool> null, başarısız veya true ise StateException fırlatır
    /// </summary>
    /// <param name="response">Kontrol edilecek ResponseState<bool></param>
    /// <param name="stateCode">Fırlatılacak StateCode</param>
    /// <exception cref="StateException">Response null, başarısız veya true ise fırlatılır</exception>
    public static void ThrowIfTrue(ResponseState<bool>? response, StateCode stateCode)
    {
        if (response is null || !response.Status.Success || response.Content)
            throw new StateException(stateCode);
    }

    /// <summary>
    /// ResponseState<bool> null, başarısız veya true ise StateException fırlatır (özel mesaj ile)
    /// </summary>
    /// <param name="response">Kontrol edilecek ResponseState<bool></param>
    /// <param name="stateCode">Fırlatılacak StateCode</param>
    /// <param name="message">Özel hata mesajı</param>
    /// <exception cref="StateException">Response null, başarısız veya true ise fırlatılır</exception>
    public static void ThrowIfTrue(ResponseState<bool>? response, StateCode stateCode, string message)
    {
        if (response is null || !response.Status.Success || response.Content)
            throw new StateException(stateCode, message);
    }

    /// <summary>
    /// ResponseState<bool> null, başarısız veya false ise StateException fırlatır
    /// </summary>
    /// <param name="response">Kontrol edilecek ResponseState<bool></param>
    /// <param name="stateCode">Fırlatılacak StateCode</param>
    /// <exception cref="StateException">Response null, başarısız veya false ise fırlatılır</exception>
    public static void ThrowIfFalse(ResponseState<bool>? response, StateCode stateCode)
    {
        if (response is null || !response.Status.Success || !response.Content)
            throw new StateException(stateCode);
    }

    /// <summary>
    /// ResponseState<bool> null, başarısız veya false ise StateException fırlatır (özel mesaj ile)
    /// </summary>
    /// <param name="response">Kontrol edilecek ResponseState<bool></param>
    /// <param name="stateCode">Fırlatılacak StateCode</param>
    /// <param name="message">Özel hata mesajı</param>
    /// <exception cref="StateException">Response null, başarısız veya false ise fırlatılır</exception>
    public static void ThrowIfFalse(ResponseState<bool>? response, StateCode stateCode, string message)
    {
        if (response is null || !response.Status.Success || !response.Content)
            throw new StateException(stateCode, message);
    }

    // ========== ResponseState<bool?> - Nullable ==========

    /// <summary>
    /// ResponseState<bool?> null, başarısız, Content null veya true ise StateException fırlatır
    /// </summary>
    /// <param name="response">Kontrol edilecek ResponseState<bool?></param>
    /// <param name="stateCode">Fırlatılacak StateCode</param>
    /// <exception cref="StateException">Response null, başarısız, Content null veya true ise fırlatılır</exception>
    public static void ThrowIfTrue(ResponseState<bool?>? response, StateCode stateCode)
    {
        if (response is null || !response.Status.Success || response.Content is null || response.Content.Value)
            throw new StateException(stateCode);
    }

    /// <summary>
    /// ResponseState<bool?> null, başarısız, Content null veya true ise StateException fırlatır (özel mesaj ile)
    /// </summary>
    /// <param name="response">Kontrol edilecek ResponseState<bool?></param>
    /// <param name="stateCode">Fırlatılacak StateCode</param>
    /// <param name="message">Özel hata mesajı</param>
    /// <exception cref="StateException">Response null, başarısız, Content null veya true ise fırlatılır</exception>
    public static void ThrowIfTrue(ResponseState<bool?>? response, StateCode stateCode, string message)
    {
        if (response is null || !response.Status.Success || response.Content is null || response.Content.Value)
            throw new StateException(stateCode, message);
    }

    /// <summary>
    /// ResponseState<bool?> null, başarısız, Content null veya false ise StateException fırlatır
    /// </summary>
    /// <param name="response">Kontrol edilecek ResponseState<bool?></param>
    /// <param name="stateCode">Fırlatılacak StateCode</param>
    /// <exception cref="StateException">Response null, başarısız, Content null veya false ise fırlatılır</exception>
    public static void ThrowIfFalse(ResponseState<bool?>? response, StateCode stateCode)
    {
        if (response is null || !response.Status.Success || response.Content is null || !response.Content.Value)
            throw new StateException(stateCode);
    }

    /// <summary>
    /// ResponseState<bool?> null, başarısız, Content null veya false ise StateException fırlatır (özel mesaj ile)
    /// </summary>
    /// <param name="response">Kontrol edilecek ResponseState<bool?></param>
    /// <param name="stateCode">Fırlatılacak StateCode</param>
    /// <param name="message">Özel hata mesajı</param>
    /// <exception cref="StateException">Response null, başarısız, Content null veya false ise fırlatılır</exception>
    public static void ThrowIfFalse(ResponseState<bool?>? response, StateCode stateCode, string message)
    {
        if (response is null || !response.Status.Success || response.Content is null || !response.Content.Value)
            throw new StateException(stateCode, message);
    }

    #endregion
}