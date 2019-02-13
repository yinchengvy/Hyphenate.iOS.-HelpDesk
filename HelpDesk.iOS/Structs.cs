using System;
using ObjCRuntime;

namespace HelpDesk.iOS
{
	[Native]
	public enum HDCallStreamType : ulong
	{
		Normal,
		DeskTop
	}

	public enum HDCallViewScaleMode : uint
	{
		t = 0,
		ll = 1
	}

	public enum HDMediaNoticeCode : uint
	{
		None = 0,
		Stats = 100,
		Disconn = 120,
		Reconn = 121,
		PoorQuality = 122,
		PublishSetup = 123,
		SubscriptionSetup = 124,
		TakePicture = 125,
		CustomMsg = 126,
		OpenCameraFail = 201,
		OpenMicFail = 202
	}

	public enum HDErrorCode : uint
	{
		General = 1,
		NetworkUnavailable,
		DatabaseOperationFailed,
		InvalidAppkey = 100,
		InvalidUsername,
		InvalidPassword,
		InvalidURL,
		UserAlreadyLogin = 200,
		UserNotLogin,
		UserAuthenticationFailed,
		UserAlreadyExist,
		UserNotFound,
		UserIllegalArgument,
		UserLoginOnAnotherDevice,
		UserRemoved,
		UserRegisterFailed,
		UpdateApnsConfigsFailed,
		UserPermissionDenied,
		ServerNotReachable = 300,
		ServerTimeout,
		ServerBusy,
		ServerUnknownError,
		ServerGetDNSConfigFailed,
		ServerServingForbidden,
		FileNotFound = 400,
		FileInvalid,
		FileUploadFailed,
		FileDownloadFailed,
		MessageInvalid = 500,
		MessageIncludeIllegalContent,
		MessageTrafficLimit,
		MessageEncryption,
		GroupInvalidId = 600,
		GroupAlreadyJoined,
		GroupNotJoined,
		GroupPermissionDenied,
		GroupMHbersFull,
		GroupNotExist,
		CallReasonHangup = 800,
		CallReasonNoResponse,
		CallReasonReject,
		CallReasonBusy,
		CallReasonFail,
		CallReasonUnspported,
		CallReasonOtherDevice,
		CallReasonDismiss
	}

	public enum HDMessageStatus : uint
	{
		Pending = 0,
		Delivering,
		Successed,
		Failed
	}

	public enum HDMessageDirection : uint
	{
		Send = 0,
		Receive
	}

	public enum HDMessageSearchDirection : uint
	{
		Up = 0,
		Down
	}

	[Native]
	public enum HConversationType : ulong
	{
		System = 0,
		Custom
	}

	[Native]
	public enum HSessionType : ulong
	{
		Prepare,
		Wait,
		Scheduling,
		Processing,
		Terminal,
		Transfer,
		Abort,
		Resolved
	}

	public enum HConnectionState : uint
	{
		Connected = 0,
		Disconnected
	}

	[Native]
	public enum AttachmentType : ulong
	{
		Image = 1,
		File,
		Audio
	}

	[Native]
	public enum Status : ulong
	{
		Status_1 = 0,
		Status_2,
		Status_3
	}

	public enum HDPushDisplayStyle : uint
	{
		SimpleBanner = 0,
		MessageSummary
	}

	public enum HPushNoDisturbStatus : uint
	{
		Day = 0,
		Custom,
		Close
	}

	public enum HDExtMsgType : uint
	{
		GeneralMsg,
		EvaluationMsg,
		OrderMsg,
		TrackMsg,
		FormMsg,
		RobotMenuMsg,
		ArticleMsg,
		ToCustomServiceMsg,
		BigExpressionMsg
	}

    public static class DefineConstants
    {
        // HDPushOptions.h
        public static readonly string PushNickname = "nickname";
        public static readonly string PushDisplayStyle = "notification_display_style";
        public static readonly string PushNoDisturbing = "notification_no_disturbing";
        public static readonly string PushNoDisturbingStartH = "notification_no_disturbing_start";
        public static readonly string PushNoDisturbingStartM = "notification_no_disturbing_startM";
        public static readonly string PushNoDisturbingEndH = "notification_no_disturbing_end";
        public static readonly string PushNoDisturbingEndM = "notification_no_disturbing_endM";

    }
}
