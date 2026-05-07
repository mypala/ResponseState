namespace ResponseState.Enums;

public class StateCode
{
    private readonly int _code;
    private readonly double _subCode;
    private readonly string _message;
    private readonly bool _success;
    private readonly MessageLevel _level;

    public int Code { get { return _code; } }
    public double SubCode { get { return _subCode; } }
    public string Message { get { return _message; } }
    public bool Success { get { return _success; } }
    public MessageLevel Level { get { return _level; } }

    public StateCode() { }

    public StateCode(int code, double subCode, string message, bool success, MessageLevel level)
    {
        _code = code;
        _subCode = subCode;
        _message = message;
        _success = success;
        _level = level;
    }

    public StateCode(int code, string message, bool success, MessageLevel level)
    {
        _code = code;
        _subCode = code;
        _message = message;
        _success = success;
        _level = level;
    }

    #region ENUMS

    #region 1xx Informational
    public static StateCode Continue = new(100, "Devam et", true, MessageLevel.Info);
    public static StateCode SwitchingProtocols = new(101, "Anahtarlama Protokolleri", true, MessageLevel.Info);
    public static StateCode Processing = new(102, "İşleme (WebDAV)", true, MessageLevel.Info);
    #endregion

    #region 2xx Success
    public static StateCode OK = new(200, "Başarılı", true, MessageLevel.Success);
    public static StateCode Created = new(201, "Oluşturdu", true, MessageLevel.Success);
    public static StateCode Accepted = new(202, "Kabul Edildi", true, MessageLevel.Success);
    public static StateCode NonAuthoritativeInformation = new(203, "Yetkilendirilmemiş Bilgi", true, MessageLevel.Success);
    public static StateCode NoContent = new(204, "İçerik Yok", true, MessageLevel.Success);
    public static StateCode ResetContent = new(205, "Başarılı", true, MessageLevel.Success);
    public static StateCode PartialContent = new(206, "Kısmi İçerik", true, MessageLevel.Success);
    public static StateCode MultiStatus = new(207, "Çoklu Durum", true, MessageLevel.Success);
    public static StateCode AlreadyReported = new(208, "Önceden Bildirilen", true, MessageLevel.Success);
    public static StateCode IMUsed = new(209, "IM Used", true, MessageLevel.Success);
    #endregion

    #region 3xx Redirection
    public static StateCode MultipleChoices = new(300, "Çoklu Seçim", true, MessageLevel.Info);
    public static StateCode MovedPermanently = new(301, "Kalıcı Olarak Taşındı", true, MessageLevel.Info);
    public static StateCode Found = new(302, "Bulundu", true, MessageLevel.Info);
    public static StateCode SeeOther = new(303, "Diğerine Bak", true, MessageLevel.Info);
    public static StateCode NotModified = new(304, "Değiştirilemedi", true, MessageLevel.Info);
    public static StateCode UseProxy = new(305, "Proxy Kullan", true, MessageLevel.Info);
    public static StateCode Unused = new(306, "Kullanılmamış", true, MessageLevel.Info);
    public static StateCode TemporaryRedirect = new(307, "Geçici Yönlendirme", true, MessageLevel.Info);
    public static StateCode PermanentRedirect = new(308, "Kalıcı Yönlendirme", true, MessageLevel.Info);
    #endregion

    #region 4xx Client Error
    public static StateCode BadRequest = new(400, "Hatalı İstek", false, MessageLevel.Error);
    public static StateCode Unauthorized = new(401, "Yetkisiz", false, MessageLevel.Error);
    public static StateCode PaymentRequired = new(402, "Ödeme Gerekli", false, MessageLevel.Error);
    public static StateCode Forbidden = new(403, "Yasaklanmış", false, MessageLevel.Error);
    public static StateCode NotFound = new(404, "Bulunamadı", false, MessageLevel.Error);
    public static StateCode MethodNotAllowed = new(405, "İzin Verilmeyen Metod", false, MessageLevel.Error);
    public static StateCode NotAcceptable = new(406, "Kabul Edilemez", false, MessageLevel.Error);
    public static StateCode ProxyAuthenticationRequired = new(407, "Proxy Kimlik Doğrulaması Gerekli", false, MessageLevel.Error);
    public static StateCode RequestTimeout = new(408, "İstek Zaman Aşımına Uğradı", false, MessageLevel.Error);
    public static StateCode Conflict = new(409, "İstek Çatışması", false, MessageLevel.Error);
    public static StateCode Gone = new(410, "Yok Olmuş - Erişilemez", false, MessageLevel.Error);
    public static StateCode LengthRequired = new(411, "İçerik Uzunluğu Gerekli", false, MessageLevel.Error);
    public static StateCode PreconditionFailed = new(412, "Önkoşul Başarısız", false, MessageLevel.Error);
    public static StateCode RequestEntityTooLarge = new(413, "Gönderilen Veri Çok Fazla", false, MessageLevel.Error);
    public static StateCode RequestURITooLong = new(414, "İstek URL'li Çok Uzun", false, MessageLevel.Error);
    public static StateCode UnsupportedMediaType = new(415, "Desteklenmeyen Medya Türü", false, MessageLevel.Error);
    public static StateCode RequestedRangeNotSatisfiable = new(416, "İstenen Aralık Uygun Değildir", false, MessageLevel.Error);
    public static StateCode ExpectationFailed = new(417, "Beklenti Başarısız oldu", false, MessageLevel.Error);
    public static StateCode IMaTeapot = new(418, "IMaTeapot", false, MessageLevel.Error);
    public static StateCode EnhanceYourCalm = new(420, "Sakinleştirin", false, MessageLevel.Error);
    public static StateCode UnprocessableEntity = new(422, "İşlenemez Varlık", false, MessageLevel.Error);
    public static StateCode Locked = new(423, "Kilitli", false, MessageLevel.Error);
    public static StateCode FailedDependency = new(424, "Başarısız Bağımlılık", false, MessageLevel.Error);
    public static StateCode ReservedforWebDAV = new(425, "WebDAV için ayrılmıştır", false, MessageLevel.Error);
    public static StateCode UpgradeRequired = new(426, "Yükseltme Gerekli", false, MessageLevel.Error);
    public static StateCode PreconditionRequired = new(428, "Önkoşul Gerekli", false, MessageLevel.Error);
    public static StateCode TooManyRequests = new(429, "Çok Fazla İstek", false, MessageLevel.Error);
    public static StateCode RequestHeaderFieldsTooLarge = new(431, "İsteğin Başlık Alanları Çok Büyük", false, MessageLevel.Error);
    public static StateCode NoResponseNginx = new(444, "Nginx Yanıt Vermiyor", false, MessageLevel.Error);
    public static StateCode RetryWithMicrosoft = new(449, "Microsoft ile yeniden dene", false, MessageLevel.Error);
    public static StateCode BlockedByWindowsParentalControls = new(450, "Windows Ebeveyn Denetimleri Tarafından Engellendi", false, MessageLevel.Error);
    public static StateCode UnavailableForLegalReasons = new(451, "Yasal Sebeplerden Dolayı Kullanılamaz", false, MessageLevel.Error);
    public static StateCode ClientClosedRequest = new(499, "İstemcinin Kapalı İsteği", false, MessageLevel.Error);
    #endregion

    #region 5xx Server Error
    public static StateCode InternalServerError = new(500, "İç Sunucu Hatası", false, MessageLevel.Error);
    public static StateCode NotImplemented = new(501, "İsteği Yerine Getiremedi", false, MessageLevel.Error);
    public static StateCode BadGateway = new(502, "Hatalı Ağ Geçidi", false, MessageLevel.Error);
    public static StateCode ServiceUnavailable = new(503, "Sunucu kullanılmaz.", false, MessageLevel.Error);
    public static StateCode GatewayTimeout = new(504, "GatewayTimeout", false, MessageLevel.Error);
    public static StateCode HTTPVersionNotSupported = new(505, "HTTPVersionNotSupported", false, MessageLevel.Error);
    public static StateCode VariantAlsoNegotiates = new(506, "VariantAlsoNegotiates", false, MessageLevel.Error);
    public static StateCode InsufficientStorage = new(507, "InsufficientStorage", false, MessageLevel.Error);
    public static StateCode LoopDetected = new(508, "LoopDetected", false, MessageLevel.Error);
    public static StateCode BandwidthLimitExceeded = new(509, "BandwidthLimitExceeded", false, MessageLevel.Error);
    public static StateCode NotExtended = new(510, "NotExtended", false, MessageLevel.Error);
    public static StateCode NetworkAuthenticationRequired = new(511, "NetworkAuthenticationRequired", false, MessageLevel.Error);
    public static StateCode NetworkReadTimeoutError = new(598, "NetworkReadTimeoutError", false, MessageLevel.Error);
    public static StateCode NetworkConnectTimeoutError = new(599, "NetworkConnectTimeoutError", false, MessageLevel.Error);
    #endregion

    #region Application Success
    public static StateCode ProcessSuccess = new(200, 20000, "İşlem Başarılı", true, MessageLevel.Success);
    public static StateCode Added = new(200, 20050, "Kayıt eklendi.", true, MessageLevel.Success);
    public static StateCode Updated = new(200, 20051, "Kayıt güncellendi.", true, MessageLevel.Success);
    public static StateCode Deleted = new(200, 20052, "Kayıt silindi.", true, MessageLevel.Success);
    public static StateCode StatusChanged = new(200, 20053, "Kaydın durumu değiştirildi.", true, MessageLevel.Success);
    public static StateCode Restored = new(200, 20054, "Kayıt başarıyla geri yüklendi.", true, MessageLevel.Success);
    #endregion

    #region Application Warning
    public static StateCode NothingChanged = new(200, 20054, "Herhangi bir değişiklik yapılmadı, kaydetmek için önce bir düzenleme yapmalısınız.", true, MessageLevel.Warning);
    #endregion

    #region Application Errors
    public static StateCode Error = new(400, 40000, "İşlem Başarısız", false, MessageLevel.Error);
    public static StateCode UnexpectedError = new(400, 40001, "Beklenilmeyen bir hata ile karşılaşıldığından, işleminiz tamamlanamamıştır.", false, MessageLevel.Error);
    public static StateCode ValidationError = new(400, 40002, "Eksik bilgi ile karşılaşıldığından, işleminiz tamamlanamamıştır.", false, MessageLevel.Error);
    public static StateCode UnexpectedBodyError = new(400, 40003, "İstek gövdesi geçersiz veya eksiksiz. Lütfen geçerli bir JSON gönderin.", false, MessageLevel.Error);
    public static StateCode HasRecordError = new(400, 40004, "Aynı kayıt birden fazla eklenemez.", false, MessageLevel.Error);
    public static StateCode EmptyRecordError = new(400, 40005, "Boş kayıt eklenemez.", false, MessageLevel.Error);
    public static StateCode CSRFNotValidToken = new(400, 40006, "CSRF token doğrulaması başarısız oldu. Lütfen tekrar deneyin.", false, MessageLevel.Error);
    public static StateCode LimitRateExceeded = new(429, 40007, "İstek sınırı aşıldı. Lütfen daha sonra tekrar deneyin.", false, MessageLevel.Error);

    #region General Validation Errors
    public static StateCode NullParameterError = new(400, 40020, "Parametre null olamaz.", false, MessageLevel.Error);
    public static StateCode InvalidParameterError = new(400, 40021, "Geçersiz parametre.", false, MessageLevel.Error);
    public static StateCode DuplicateRecordError = new(400, 40022, "Kayıt zaten mevcut.", false, MessageLevel.Error);
    public static StateCode NoRecordFoundError = new(404, 40023, "Kayıt bulunamadı.", false, MessageLevel.Error);
    public static StateCode LoadTableNotUploadError = new(400, 40024, "Tablo yüklenmedi", false, MessageLevel.Error);
    #endregion

    public static StateCode NotAdded = new(400, 40052, "Kayıt eklenemedi.", false, MessageLevel.Error);
    public static StateCode NotUpdated = new(400, 40053, "Kayıt güncellenemedi.", false, MessageLevel.Error);
    public static StateCode NotDeleted = new(400, 40054, "Kayıt silinemedi.", false, MessageLevel.Error);
    public static StateCode NotStatusChanged = new(400, 40055, "Kaydın durumu değiştirilemedi.", false, MessageLevel.Error);
    public static StateCode NotFoundNewEntity = new(400, 40056, "Değiştirilecek kayıt bulunamadı.", false, MessageLevel.Error);
    public static StateCode NotFoundIncludedProperties = new(400, 40057, "Değiştirilecek kaydın özellikleri bulunamadı.", false, MessageLevel.Error);
    public static StateCode NotDeletedHasRelations = new(400, 40058, "Kayıt silinemedi. İlişkili veriler bulundu:\n- {0}", false, MessageLevel.Error);
    public static StateCode NotRestored = new(400, 40059, "Kayıt geri yüklenemedi.", false, MessageLevel.Error);

    public static StateCode UnAuthenticated = new(400, 40099, "Oturum süresi dolmuştur.", false, MessageLevel.Error);
    public static StateCode UnAuthorizedModule = new(401, 40100, "Bu modüle erişim yetkiniz bulunmamaktadır.", false, MessageLevel.Error);
    public static StateCode MissingAuthorization = new(401, 40101, "Yetkilendirme (Authorization) başlığı eksik veya geçersiz.", false, MessageLevel.Error);
    public static StateCode NotFoundModule = new(401, 40102, "Aradığınız modül bulunmamaktadır.", false, MessageLevel.Error);
    public static StateCode NotResolved = new (401, 40103, "Modül çözümlenmedi.", false, MessageLevel.Error);
    #endregion

    #endregion
}