using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dorner.BlogEngineCore
{
    public static class BlogEngineConstants
    {
        public static class RssRequest
        {

            public const string BlogId = "blog_id";
            
        }

        public static class RssErrors
        {
            // OAuth2 errors
            public const string InvalidRequest = "invalid_request";
            public const string UnauthorizedClient = "unauthorized_client";
            public const string AccessDenied = "access_denied";
            public const string UnsupportedResponseType = "unsupported_response_type";
            public const string InvalidScope = "invalid_scope";
            public const string ServerError = "server_error";
            public const string TemporarilyUnavailable = "temporarily_unavailable";

            // OIDC errors
            public const string InteractionRequired = "interaction_required";
            public const string LoginRequired = "login_required";
            public const string AccountSelectionRequired = "account_selection_required";
            public const string ConsentRequired = "consent_required";
            public const string InvalidRequestUri = "invalid_request_uri";
            public const string InvalidRequestObject = "invalid_request_object";
            public const string RequestNotSupported = "request_not_supported";
            public const string RequestUriNotSupported = "request_uri_not_supported";
            public const string RegistrationNotSupported = "registration_not_supported";
        }

        public static class RssResponse
        {
            public const string Scope = "scope";
            public const string Code = "code";
            public const string AccessToken = "access_token";
            public const string ExpiresIn = "expires_in";
            public const string TokenType = "token_type";
            public const string RefreshToken = "refresh_token";
            public const string IdentityToken = "id_token";
            public const string State = "state";
            public const string Error = "error";
        }

        public static class ResponseModes
        {
            public const string FormPost = "form_post";
            public const string Query = "query";
            public const string Fragment = "fragment";
        }

        public static class DisplayModes
        {
            public const string Page = "page";
            public const string Popup = "popup";
            public const string Touch = "touch";
            public const string Wap = "wap";
        }

        public static class PromptModes
        {
            public const string None = "none";
            public const string Login = "login";
            public const string Consent = "consent";
            public const string SelectAccount = "select_account";
        }
    }
}
