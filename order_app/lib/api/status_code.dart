// ignore_for_file: constant_identifier_names

class HttpStatusCode {
  //
  // Summary:
  //     Equivalent to HTTP status 100. System.Net.HttpStatusCode.Continue indicates that
  //     the client can continue with its request.
  static const int Continue = 100;
  //
  // Summary:
  //     Equivalent to HTTP status 101. System.Net.HttpStatusCode.SwitchingProtocols indicates
  //     that the protocol version or protocol is being changed.
  static const int SwitchingProtocols = 101;
  //
  // Summary:
  //     Equivalent to HTTP status 102. System.Net.HttpStatusCode.Processing indicates
  //     that the server has accepted the complete request but hasn't completed it yet.
  static const int Processing = 102;
  //
  // Summary:
  //     Equivalent to HTTP status 103. System.Net.HttpStatusCode.EarlyHints indicates
  //     to the client that the server is likely to send a final response with the header
  //     fields included in the informational response.
  static const int EarlyHints = 103;
  //
  // Summary:
  //     Equivalent to HTTP status 200. System.Net.HttpStatusCode.OK indicates that the
  //     request succeeded and that the requested information is in the response. This
  //     is the most common status code to receive.
  static const int OK = 200;
  //
  // Summary:
  //     Equivalent to HTTP status 201. System.Net.HttpStatusCode.Created indicates that
  //     the request resulted in a new resource created before the response was sent.
  static const int Created = 201;
  //
  // Summary:
  //     Equivalent to HTTP status 202. System.Net.HttpStatusCode.Accepted indicates that
  //     the request has been accepted for further processing.
  static const int Accepted = 202;
  //
  // Summary:
  //     Equivalent to HTTP status 203. System.Net.HttpStatusCode.NonAuthoritativeInformation
  //     indicates that the returned meta information is from a cached copy instead of
  //     the origin server and therefore may be incorrect.
  static const int NonAuthoritativeInformation = 203;
  //
  // Summary:
  //     Equivalent to HTTP status 204. System.Net.HttpStatusCode.NoContent indicates
  //     that the request has been successfully processed and that the response is intentionally
  //     blank.
  static const int NoContent = 204;
  //
  // Summary:
  //     Equivalent to HTTP status 205. System.Net.HttpStatusCode.ResetContent indicates
  //     that the client should reset (not reload) the current resource.
  static const int ResetContent = 205;
  //
  // Summary:
  //     Equivalent to HTTP status 206. System.Net.HttpStatusCode.PartialContent indicates
  //     that the response is a partial response as requested by a GET request that includes
  //     a byte range.
  static const int PartialContent = 206;
  //
  // Summary:
  //     Equivalent to HTTP status 207. System.Net.HttpStatusCode.MultiStatus indicates
  //     multiple status codes for a single response during a Web Distributed Authoring
  //     and Versioning (WebDAV) operation. The response body contains XML that describes
  //     the status codes.
  static const int MultiStatus = 207;
  //
  // Summary:
  //     Equivalent to HTTP status 208. System.Net.HttpStatusCode.AlreadyReported indicates
  //     that the members of a WebDAV binding have already been enumerated in a preceding
  //     part of the multistatus response; and are not being included again.
  static const int AlreadyReported = 208;
  //
  // Summary:
  //     Equivalent to HTTP status 226. System.Net.HttpStatusCode.IMUsed indicates that
  //     the server has fulfilled a request for the resource; and the response is a representation
  //     of the result of one or more instance-manipulations applied to the current instance.
  static const int IMUsed = 226;
  //
  // Summary:
  //     Equivalent to HTTP status 300. System.Net.HttpStatusCode.Ambiguous indicates
  //     that the requested information has multiple representations. The default action
  //     is to treat this status as a redirect and follow the contents of the Location
  //     header associated with this response. Ambiguous is a synonym for MultipleChoices.
  static const int Ambiguous = 300;
  //
  // Summary:
  //     Equivalent to HTTP status 300. System.Net.HttpStatusCode.MultipleChoices indicates
  //     that the requested information has multiple representations. The default action
  //     is to treat this status as a redirect and follow the contents of the Location
  //     header associated with this response. MultipleChoices is a synonym for Ambiguous.
  static const int MultipleChoices = 300;
  //
  // Summary:
  //     Equivalent to HTTP status 301. System.Net.HttpStatusCode.Moved indicates that
  //     the requested information has been moved to the URI specified in the Location
  //     header. The default action when this status is received is to follow the Location
  //     header associated with the response. When the original request method was POST;
  //     the redirected request will use the GET method. Moved is a synonym for MovedPermanently.
  static const int Moved = 301;
  //
  // Summary:
  //     Equivalent to HTTP status 301. System.Net.HttpStatusCode.MovedPermanently indicates
  //     that the requested information has been moved to the URI specified in the Location
  //     header. The default action when this status is received is to follow the Location
  //     header associated with the response. MovedPermanently is a synonym for Moved.
  static const int MovedPermanently = 301;
  //
  // Summary:
  //     Equivalent to HTTP status 302. System.Net.HttpStatusCode.Found indicates that
  //     the requested information is located at the URI specified in the Location header.
  //     The default action when this status is received is to follow the Location header
  //     associated with the response. When the original request method was POST; the
  //     redirected request will use the GET method. Found is a synonym for Redirect.
  static const int Found = 302;
  //
  // Summary:
  //     Equivalent to HTTP status 302. System.Net.HttpStatusCode.Redirect indicates that
  //     the requested information is located at the URI specified in the Location header.
  //     The default action when this status is received is to follow the Location header
  //     associated with the response. When the original request method was POST; the
  //     redirected request will use the GET method. Redirect is a synonym for Found.
  static const int Redirect = 302;
  //
  // Summary:
  //     Equivalent to HTTP status 303. System.Net.HttpStatusCode.RedirectMethod automatically
  //     redirects the client to the URI specified in the Location header as the result
  //     of a POST. The request to the resource specified by the Location header will
  //     be made with a GET. RedirectMethod is a synonym for SeeOther.
  static const int RedirectMethod = 303;
  //
  // Summary:
  //     Equivalent to HTTP status 303. System.Net.HttpStatusCode.SeeOther automatically
  //     redirects the client to the URI specified in the Location header as the result
  //     of a POST. The request to the resource specified by the Location header will
  //     be made with a GET. SeeOther is a synonym for RedirectMethod.
  static const int SeeOther = 303;
  //
  // Summary:
  //     Equivalent to HTTP status 304. System.Net.HttpStatusCode.NotModified indicates
  //     that the client's cached copy is up to date. The contents of the resource are
  //     not transferred.
  static const int NotModified = 304;
  //
  // Summary:
  //     Equivalent to HTTP status 305. System.Net.HttpStatusCode.UseProxy indicates that
  //     the request should use the proxy server at the URI specified in the Location
  //     header.
  static const int UseProxy = 305;
  //
  // Summary:
  //     Equivalent to HTTP status 306. System.Net.HttpStatusCode.Unused is a proposed
  //     extension to the HTTP/1.1 specification that is not fully specified.
  static const int Unused = 306;
  //
  // Summary:
  //     Equivalent to HTTP status 307. System.Net.HttpStatusCode.RedirectKeepVerb indicates
  //     that the request information is located at the URI specified in the Location
  //     header. The default action when this status is received is to follow the Location
  //     header associated with the response. When the original request method was POST;
  //     the redirected request will also use the POST method. RedirectKeepVerb is a synonym
  //     for TemporaryRedirect.
  static const int RedirectKeepVerb = 307;
  //
  // Summary:
  //     Equivalent to HTTP status 307. System.Net.HttpStatusCode.TemporaryRedirect indicates
  //     that the request information is located at the URI specified in the Location
  //     header. The default action when this status is received is to follow the Location
  //     header associated with the response. When the original request method was POST;
  //     the redirected request will also use the POST method. TemporaryRedirect is a
  //     synonym for RedirectKeepVerb.
  static const int TemporaryRedirect = 307;
  //
  // Summary:
  //     Equivalent to HTTP status 308. System.Net.HttpStatusCode.PermanentRedirect indicates
  //     that the request information is located at the URI specified in the Location
  //     header. The default action when this status is received is to follow the Location
  //     header associated with the response. When the original request method was POST;
  //     the redirected request will also use the POST method.
  static const int PermanentRedirect = 308;
  //
  // Summary:
  //     Equivalent to HTTP status 400. System.Net.HttpStatusCode.BadRequest indicates
  //     that the request could not be understood by the server. System.Net.HttpStatusCode.BadRequest
  //     is sent when no other error is applicable; or if the exact error is unknown or
  //     does not have its own error code.
  static const int BadRequest = 400;
  //
  // Summary:
  //     Equivalent to HTTP status 401. System.Net.HttpStatusCode.Unauthorized indicates
  //     that the requested resource requires authentication. The WWW-Authenticate header
  //     contains the details of how to perform the authentication.
  static const int Unauthorized = 401;
  //
  // Summary:
  //     Equivalent to HTTP status 402. System.Net.HttpStatusCode.PaymentRequired is reserved
  //     for future use.
  static const int PaymentRequired = 402;
  //
  // Summary:
  //     Equivalent to HTTP status 403. System.Net.HttpStatusCode.Forbidden indicates
  //     that the server refuses to fulfill the request.
  static const int Forbidden = 403;
  //
  // Summary:
  //     Equivalent to HTTP status 404. System.Net.HttpStatusCode.NotFound indicates that
  //     the requested resource does not exist on the server.
  static const int NotFound = 404;
  //
  // Summary:
  //     Equivalent to HTTP status 405. System.Net.HttpStatusCode.MethodNotAllowed indicates
  //     that the request method (POST or GET) is not allowed on the requested resource.
  static const int MethodNotAllowed = 405;
  //
  // Summary:
  //     Equivalent to HTTP status 406. System.Net.HttpStatusCode.NotAcceptable indicates
  //     that the client has indicated with Accept headers that it will not accept any
  //     of the available representations of the resource.
  static const int NotAcceptable = 406;
  //
  // Summary:
  //     Equivalent to HTTP status 407. System.Net.HttpStatusCode.ProxyAuthenticationRequired
  //     indicates that the requested proxy requires authentication. The Proxy-authenticate
  //     header contains the details of how to perform the authentication.
  static const int ProxyAuthenticationRequired = 407;
  //
  // Summary:
  //     Equivalent to HTTP status 408. System.Net.HttpStatusCode.RequestTimeout indicates
  //     that the client did not send a request within the time the server was expecting
  //     the request.
  static const int RequestTimeout = 408;
  //
  // Summary:
  //     Equivalent to HTTP status 409. System.Net.HttpStatusCode.Conflict indicates that
  //     the request could not be carried out because of a conflict on the server.
  static const int Conflict = 409;
  //
  // Summary:
  //     Equivalent to HTTP status 410. System.Net.HttpStatusCode.Gone indicates that
  //     the requested resource is no longer available.
  static const int Gone = 410;
  //
  // Summary:
  //     Equivalent to HTTP status 411. System.Net.HttpStatusCode.LengthRequired indicates
  //     that the required Content-length header is missing.
  static const int LengthRequired = 411;
  //
  // Summary:
  //     Equivalent to HTTP status 412. System.Net.HttpStatusCode.PreconditionFailed indicates
  //     that a condition set for this request failed; and the request cannot be carried
  //     out. Conditions are set with conditional request headers like If-Match; If-None-Match;
  //     or If-Unmodified-Since.
  static const int PreconditionFailed = 412;
  //
  // Summary:
  //     Equivalent to HTTP status 413. System.Net.HttpStatusCode.RequestEntityTooLarge
  //     indicates that the request is too large for the server to process.
  static const int RequestEntityTooLarge = 413;
  //
  // Summary:
  //     Equivalent to HTTP status 414. System.Net.HttpStatusCode.RequestUriTooLong indicates
  //     that the URI is too long.
  static const int RequestUriTooLong = 414;
  //
  // Summary:
  //     Equivalent to HTTP status 415. System.Net.HttpStatusCode.UnsupportedMediaType
  //     indicates that the request is an unsupported type.
  static const int UnsupportedMediaType = 415;
  //
  // Summary:
  //     Equivalent to HTTP status 416. System.Net.HttpStatusCode.RequestedRangeNotSatisfiable
  //     indicates that the range of data requested from the resource cannot be returned;
  //     either because the beginning of the range is before the beginning of the resource;
  //     or the end of the range is after the end of the resource.
  static const int RequestedRangeNotSatisfiable = 416;
  //
  // Summary:
  //     Equivalent to HTTP status 417. System.Net.HttpStatusCode.ExpectationFailed indicates
  //     that an expectation given in an Expect header could not be met by the server.
  static const int ExpectationFailed = 417;
  //
  // Summary:
  //     Equivalent to HTTP status 421. System.Net.HttpStatusCode.MisdirectedRequest indicates
  //     that the request was directed at a server that is not able to produce a response.
  static const int MisdirectedRequest = 421;
  //
  // Summary:
  //     Equivalent to HTTP status 422. System.Net.HttpStatusCode.UnprocessableEntity
  //     indicates that the request was well-formed but was unable to be followed due
  //     to semantic errors.
  static const int UnprocessableEntity = 422;
  //
  // Summary:
  //     Equivalent to HTTP status 423. System.Net.HttpStatusCode.Locked indicates that
  //     the source or destination resource is locked.
  static const int Locked = 423;
  //
  // Summary:
  //     Equivalent to HTTP status 424. System.Net.HttpStatusCode.FailedDependency indicates
  //     that the method couldn't be performed on the resource because the requested action
  //     depended on another action and that action failed.
  static const int FailedDependency = 424;
  //
  // Summary:
  //     Equivalent to HTTP status 426. System.Net.HttpStatusCode.UpgradeRequired indicates
  //     that the client should switch to a different protocol such as TLS/1.0.
  static const int UpgradeRequired = 426;
  //
  // Summary:
  //     Equivalent to HTTP status 428. System.Net.HttpStatusCode.PreconditionRequired
  //     indicates that the server requires the request to be conditional.
  static const int PreconditionRequired = 428;
  //
  // Summary:
  //     Equivalent to HTTP status 429. System.Net.HttpStatusCode.TooManyRequests indicates
  //     that the user has sent too many requests in a given amount of time.
  static const int TooManyRequests = 429;
  //
  // Summary:
  //     Equivalent to HTTP status 431. System.Net.HttpStatusCode.RequestHeaderFieldsTooLarge
  //     indicates that the server is unwilling to process the request because its header
  //     fields (either an individual header field or all the header fields collectively)
  //     are too large.
  static const int RequestHeaderFieldsTooLarge = 431;
  //
  // Summary:
  //     Equivalent to HTTP status 451. System.Net.HttpStatusCode.UnavailableForLegalReasons
  //     indicates that the server is denying access to the resource as a consequence
  //     of a legal demand.
  static const int UnavailableForLegalReasons = 451;
  //
  // Summary:
  //     Equivalent to HTTP status 500. System.Net.HttpStatusCode.InternalServerError
  //     indicates that a generic error has occurred on the server.
  static const int InternalServerError = 500;
  //
  // Summary:
  //     Equivalent to HTTP status 501. System.Net.HttpStatusCode.NotImplemented indicates
  //     that the server does not support the requested function.
  static const int NotImplemented = 501;
  //
  // Summary:
  //     Equivalent to HTTP status 502. System.Net.HttpStatusCode.BadGateway indicates
  //     that an intermediate proxy server received a bad response from another proxy
  //     or the origin server.
  static const int BadGateway = 502;
  //
  // Summary:
  //     Equivalent to HTTP status 503. System.Net.HttpStatusCode.ServiceUnavailable indicates
  //     that the server is temporarily unavailable; usually due to high load or maintenance.
  static const int ServiceUnavailable = 503;
  //
  // Summary:
  //     Equivalent to HTTP status 504. System.Net.HttpStatusCode.GatewayTimeout indicates
  //     that an intermediate proxy server timed out while waiting for a response from
  //     another proxy or the origin server.
  static const int GatewayTimeout = 504;
  //
  // Summary:
  //     Equivalent to HTTP status 505. System.Net.HttpStatusCode.HttpVersionNotSupported
  //     indicates that the requested HTTP version is not supported by the server.
  static const int HttpVersionNotSupported = 505;
  //
  // Summary:
  //     Equivalent to HTTP status 506. System.Net.HttpStatusCode.VariantAlsoNegotiates
  //     indicates that the chosen variant resource is configured to engage in transparent
  //     content negotiation itself and; therefore; isn't a proper endpoint in the negotiation
  //     process.
  static const int VariantAlsoNegotiates = 506;
  //
  // Summary:
  //     Equivalent to HTTP status 507. System.Net.HttpStatusCode.InsufficientStorage
  //     indicates that the server is unable to store the representation needed to complete
  //     the request.
  static const int InsufficientStorage = 507;
  //
  // Summary:
  //     Equivalent to HTTP status 508. System.Net.HttpStatusCode.LoopDetected indicates
  //     that the server terminated an operation because it encountered an infinite loop
  //     while processing a WebDAV request with "Depth: infinity". This status code is
  //     meant for backward compatibility with clients not aware of the 208 status code
  //     System.Net.HttpStatusCode.AlreadyReported appearing in multistatus response bodies.
  static const int LoopDetected = 508;
  //
  // Summary:
  //     Equivalent to HTTP status 510. System.Net.HttpStatusCode.NotExtended indicates
  //     that further extensions to the request are required for the server to fulfill
  //     it.
  static const int NotExtended = 510;
  //
  // Summary:
  //     Equivalent to HTTP status 511. System.Net.HttpStatusCode.NetworkAuthenticationRequired
  //     indicates that the client needs to authenticate to gain network access; it's
  //     intended for use by intercepting proxies used to control access to the network.
  static const int NetworkAuthenticationRequired = 511;
}
