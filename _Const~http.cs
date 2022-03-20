namespace Ans.Net6.Web
{

	public static partial class _Const
	{

		// 1xx: Informational (информационные):
		public const int HTTP_100 = 100;    // Continue («продолжить»).
		public const int HTTP_101 = 101;    // Switching Protocols («переключение протоколов»).
		public const int HTTP_102 = 102;    // Processing («идёт обработка»).

		// 2xx: Success (успешно):
		public const int HTTP_200 = 200;    // OK («хорошо»).
		public const int HTTP_201 = 201;    // Created («создано»).
		public const int HTTP_202 = 202;    // Accepted («принято»).
		public const int HTTP_203 = 203;    // Non-Authoritative Information («информация не авторитетна»).
		public const int HTTP_204 = 204;    // No Content («нет содержимого»).
		public const int HTTP_205 = 205;    // Reset Content («сбросить содержимое»).
		public const int HTTP_206 = 206;    // Partial Content («частичное содержимое»).
		public const int HTTP_207 = 207;    // Multi-Status («многостатусный»).
		public const int HTTP_226 = 226;    // IM Used («использовано IM»).

		// 3xx: Redirection (перенаправление):
		public const int HTTP_300 = 300;    // Multiple Choices («множество выборов»).
		public const int HTTP_301 = 301;    // !!! Moved Permanently («перемещено навсегда»).
		public const int HTTP_302 = 302;    // Found («найдено»).
		public const int HTTP_303 = 303;    // See Other (смотреть другое).
		public const int HTTP_304 = 304;    // Not Modified (не изменялось).
		public const int HTTP_305 = 305;    // Use Proxy («использовать прокси»).
		public const int HTTP_306 = 306;    // — зарезервировано.
		public const int HTTP_307 = 307;    // !!! Temporary Redirect («временное перенаправление»).

		// 4xx: Client Error (ошибка клиента):
		public const int HTTP_400 = 400;    // Bad Request («плохой запрос»).
		public const int HTTP_401 = 401;    // !!! Unauthorized («неавторизован»).
		public const int HTTP_402 = 402;    // !!! Payment Required («необходима оплата»).
		public const int HTTP_403 = 403;    // !!! Forbidden («запрещено»).
		public const int HTTP_404 = 404;    // !!! Not Found («не найдено»).
		public const int HTTP_405 = 405;    // Method Not Allowed («метод не поддерживается»).
		public const int HTTP_406 = 406;    // Not Acceptable («не приемлемо»).
		public const int HTTP_407 = 407;    // Proxy Authentication Required («необходима аутентификация прокси»).
		public const int HTTP_408 = 408;    // !!! Request Timeout («истекло время ожидания»).
		public const int HTTP_409 = 409;    // Conflict («конфликт»).
		public const int HTTP_410 = 410;    // Gone («удалён»).
		public const int HTTP_411 = 411;    // Length Required («необходима длина»).
		public const int HTTP_412 = 412;    // Precondition Failed («условие ложно»).
		public const int HTTP_413 = 413;    // !!! Request Entity Too Large («размер запроса слишком велик»).
		public const int HTTP_414 = 414;    // !!! Request-URI Too Long («запрашиваемый URI слишком длинный»).
		public const int HTTP_415 = 415;    // !!! Unsupported Media Type («неподдерживаемый тип данных»).
		public const int HTTP_416 = 416;    // Requested Range Not Satisfiable («запрашиваемый диапазон не достижим»).
		public const int HTTP_417 = 417;    // Expectation Failed («ожидаемое не приемлемо»[источник не указан 33 дня]).
		public const int HTTP_422 = 422;    // Unprocessable Entity («необрабатываемый экземпляр»).
		public const int HTTP_423 = 423;    // Locked («заблокировано»).
		public const int HTTP_424 = 424;    // Failed Dependency («невыполненная зависимость»).
		public const int HTTP_425 = 425;    // Unordered Collection («неупорядоченный набор»).
		public const int HTTP_426 = 426;    // Upgrade Required («необходимо обновление»).
		public const int HTTP_449 = 449;    // Retry With («повторить с»).
		public const int HTTP_456 = 456;    // Unrecoverable Error («некорректируемая ошибка»).

		// 5xx: Server Error (ошибка сервера):
		public const int HTTP_500 = 500;    // !!! Internal Server Error («внутренняя ошибка сервера»).
		public const int HTTP_501 = 501;    // Not Implemented («не реализовано»).
		public const int HTTP_502 = 502;    // Bad Gateway («плохой шлюз»).
		public const int HTTP_503 = 503;    // !!! Service Unavailable («сервис недоступен»).
		public const int HTTP_504 = 504;    // !!! Gateway Timeout («шлюз не отвечает»).
		public const int HTTP_505 = 505;    // HTTP Version Not Supported («версия HTTP не поддерживается»).
		public const int HTTP_506 = 506;    // Variant Also Negotiates («вариант тоже согласован»).
		public const int HTTP_507 = 507;    // Insufficient Storage («переполнение хранилища»).
		public const int HTTP_509 = 509;    // Bandwidth Limit Exceeded («исчерпана пропускная ширина канала»).
		public const int HTTP_510 = 510;    // Not Extended («не расширено»).

	}

}
