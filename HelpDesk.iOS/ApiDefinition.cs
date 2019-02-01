using System;
using CoreFoundation;
using Foundation;
using HelpDesk;
using ObjCRuntime;
using UIKit;
using Hyphenate.iOS.Lib;

namespace HelpDesk.iOS
{
	[Static]
	//[Verify (ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern NSString *const TAG_ROOT;
		[Field ("TAG_ROOT", "__Internal")]
		NSString TAG_ROOT { get; }

		// extern NSString *const TAG_WEICHAT;
		[Field ("TAG_WEICHAT", "__Internal")]
		NSString TAG_WEICHAT { get; }

		// extern NSString *const TAG_MSGTYPE;
		[Field ("TAG_MSGTYPE", "__Internal")]
		NSString TAG_MSGTYPE { get; }
	}

	// @interface HDContent : NSObject
	[BaseType (typeof(NSObject))]
	interface HDContent
	{
		// -(instancetype)initWithValue:(NSString *)value;
		[Export ("initWithValue:")]
		IntPtr Constructor (string value);

		// -(NSMutableDictionary *)content;
		[Export ("content")]
		//[Verify (MethodToProperty)]
		NSMutableDictionary Content { get; }

		// -(NSString *)value;
		[Export ("value")]
		//[Verify (MethodToProperty)]
		string Value { get; }

		// -(NSString *)getName;
		[Export ("getName")]
		//[Verify (MethodToProperty)]
		string Name { get; }

		// -(NSString *)getParentName;
		[Export ("getParentName")]
		//[Verify (MethodToProperty)]
		string ParentName { get; }
	}

	// @interface HDAgentIdentityInfo : HDContent
	[BaseType (typeof(HDContent))]
	interface HDAgentIdentityInfo
	{
		// @property (copy, nonatomic) NSString * agentName;
		[Export ("agentName")]
		string AgentName { get; set; }
	}

	// @interface HDAgentInfo : HDContent
	[BaseType (typeof(HDContent))]
	interface HDAgentInfo
	{
		// @property (copy, nonatomic) NSString * nickName;
		[Export ("nickName")]
		string NickName { get; set; }

		// @property (copy, nonatomic) NSString * avatar;
		[Export ("avatar")]
		string Avatar { get; set; }
	}

	// @interface HDCallMember : NSObject
	[BaseType (typeof(NSObject))]
	interface HDCallMember
	{
		// @property (readonly, nonatomic) NSString * memberName;
		[Export ("memberName")]
		string MemberName { get; }

		// @property (readonly, nonatomic) NSDictionary * extension;
		[Export ("extension")]
		NSDictionary Extension { get; }
	}

	// @interface HDCallStream : NSObject
	[BaseType (typeof(NSObject))]
	interface HDCallStream
	{
		// @property (readonly, nonatomic) NSString * streamId;
		[Export ("streamId")]
		string StreamId { get; }

		// @property (readonly, nonatomic) NSString * streamName;
		[Export ("streamName")]
		string StreamName { get; }

		// @property (readonly, nonatomic) NSString * memberName;
		[Export ("memberName")]
		string MemberName { get; }

		// @property (readonly, nonatomic) HDCallStreamType streamType;
		[Export ("streamType")]
		HDCallStreamType StreamType { get; }

		// @property (readonly, nonatomic) BOOL videoOff;
		[Export ("videoOff")]
		bool VideoOff { get; }

		// @property (readonly, nonatomic) BOOL audioOff;
		[Export ("audioOff")]
		bool AudioOff { get; }

		// @property (readonly, nonatomic) NSString * extension;
		[Export ("extension")]
		string Extension { get; }
	}

	// @interface HDCallLocalView : EMCallLocalView
	[BaseType (typeof(EMCallLocalView))]
	interface HDCallLocalView
	{
		// @property (assign, nonatomic) HDCallViewScaleMode hScaleMode;
		[Export ("hScaleMode", ArgumentSemantic.Assign)]
		HDCallViewScaleMode HScaleMode { get; set; }
	}

	// @interface HDCallRemoteView : EMCallRemoteView
	[BaseType (typeof(EMCallRemoteView))]
	interface HDCallRemoteView
	{
		// @property (assign, nonatomic) HDCallViewScaleMode hScaleMode;
		[Export ("hScaleMode", ArgumentSemantic.Assign)]
		HDCallViewScaleMode HScaleMode { get; set; }
	}

	// @interface HDError : NSObject
	[BaseType (typeof(NSObject))]
	interface HDError
	{
		// @property (nonatomic) HDErrorCode code;
		[Export ("code", ArgumentSemantic.Assign)]
		HDErrorCode Code { get; set; }

		// @property (copy, nonatomic) NSString * errorDescription;
		[Export ("errorDescription")]
		string ErrorDescription { get; set; }

		// -(instancetype)initWithDescription:(NSString *)aDescription code:(HDErrorCode)aCode;
		[Export ("initWithDescription:code:")]
		IntPtr Constructor (string aDescription, HDErrorCode aCode);

		// +(instancetype)errorWithDescription:(NSString *)aDescription code:(HDErrorCode)aCode;
		[Static]
		[Export ("errorWithDescription:code:")]
		HDError ErrorWithDescription (string aDescription, HDErrorCode aCode);
	}

	// @interface HDCallOptions : NSObject
	[BaseType (typeof(NSObject))]
	interface HDCallOptions
	{
		// @property (assign, nonatomic) BOOL videoOff;
		[Export ("videoOff")]
		bool VideoOff { get; set; }

		// @property (assign, nonatomic) BOOL mute;
		[Export ("mute")]
		bool Mute { get; set; }

		// @property (nonatomic, strong) HDCallLocalView * previewView;
		[Export ("previewView", ArgumentSemantic.Strong)]
		HDCallLocalView PreviewView { get; set; }

		// @property (assign, nonatomic) BOOL useBackCamera;
		[Export ("useBackCamera")]
		bool UseBackCamera { get; set; }

		// @property (assign, nonatomic) int videoWidth;
		[Export ("videoWidth")]
		int VideoWidth { get; set; }

		// @property (assign, nonatomic) int videoHeight;
		[Export ("videoHeight")]
		int VideoHeight { get; set; }
	}

    partial interface IHDCallManagerDelegate {}

	// @protocol HDCallManagerDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface HDCallManagerDelegate
	{
		// @optional -(void)onCallReceivedNickName:(NSString *)nickName;
		[Export ("onCallReceivedNickName:")]
		void OnCallReceivedNickName (string nickName);

		// @optional -(void)onMemberJoin:(HDCallMember *)member;
		[Export ("onMemberJoin:")]
		void OnMemberJoin (HDCallMember member);

		// @optional -(void)onMemberExit:(HDCallMember *)member;
		[Export ("onMemberExit:")]
		void OnMemberExit (HDCallMember member);

		// @optional -(void)onStreamAdd:(HDCallStream *)stream;
		[Export ("onStreamAdd:")]
		void OnStreamAdd (HDCallStream stream);

		// @optional -(void)onStreamRemove:(HDCallStream *)stream;
		[Export ("onStreamRemove:")]
		void OnStreamRemove (HDCallStream stream);

		// @optional -(void)onCallEndReason:(int)reason desc:(NSString *)desc;
		[Export ("onCallEndReason:desc:")]
		void OnCallEndReason (int reason, string desc);

		// @optional -(void)onStreamUpdate:(HDCallStream *)stream;
		[Export ("onStreamUpdate:")]
		void OnStreamUpdate (HDCallStream stream);

		// @optional -(void)onNotice:(HDMediaNoticeCode)code arg1:(NSString *)arg1 arg2:(NSString *)arg2 arg3:(id)arg3;
		[Export ("onNotice:arg1:arg2:arg3:")]
		void OnNotice (HDMediaNoticeCode code, string arg1, string arg2, NSObject arg3);
	}

	// @interface HDCompositeContent : NSObject
	[BaseType (typeof(NSObject))]
	interface HDCompositeContent
	{
		// @property (nonatomic, strong) NSMutableArray * contents;
		[Export ("contents", ArgumentSemantic.Strong)]
		NSMutableArray Contents { get; set; }

		// -(instancetype)initWithContents:(NSMutableDictionary *)obj;
		[Export ("initWithContents:")]
		IntPtr Constructor (NSMutableDictionary obj);

		// -(BOOL)isNull;
		[Export ("isNull")]
		//[Verify (MethodToProperty)]
		bool IsNull { get; }

		// -(NSMutableArray *)getContents;
		[Export ("getContents")]
		//[Verify (MethodToProperty)]
		NSMutableArray GetContents ();

		// -(NSString *)getParentName;
		[Export ("getParentName")]
		//[Verify (MethodToProperty)]
		string ParentName { get; }
	}

	// @interface HDVisitorInfo : HDContent
	[BaseType (typeof(HDContent))]
	interface HDVisitorInfo
	{
		// @property (copy, nonatomic) NSString * name;
		[Export ("name")]
		string Name { get; set; }

		// @property (copy, nonatomic) NSString * qq;
		[Export ("qq")]
		string Qq { get; set; }

		// @property (copy, nonatomic) NSString * companyName;
		[Export ("companyName")]
		string CompanyName { get; set; }

		// @property (copy, nonatomic) NSString * nickName;
		[Export ("nickName")]
		string NickName { get; set; }

		// @property (copy, nonatomic) NSString * phone;
		[Export ("phone")]
		string Phone { get; set; }

		// @property (copy, nonatomic) NSString * desc;
		[Export ("desc")]
		string Desc { get; set; }

		// @property (copy, nonatomic) NSString * email;
		[Export ("email")]
		string Email { get; set; }
	}

	// @interface HDVisitorTrack : HDContent
	[BaseType (typeof(HDContent))]
	interface HDVisitorTrack
	{
		// @property (copy, nonatomic) NSString * title;
		[Export ("title")]
		string Title { get; set; }

		// @property (copy, nonatomic) NSString * price;
		[Export ("price")]
		string Price { get; set; }

		// @property (copy, nonatomic) NSString * imageUrl;
		[Export ("imageUrl")]
		string ImageUrl { get; set; }

		// @property (copy, nonatomic) NSString * itemUrl;
		[Export ("itemUrl")]
		string ItemUrl { get; set; }

		// @property (copy, nonatomic) NSString * desc;
		[Export ("desc")]
		string Desc { get; set; }
	}

	// @interface HDOrderInfo : HDContent
	[BaseType (typeof(HDContent))]
	interface HDOrderInfo
	{
		// @property (copy, nonatomic) NSString * title;
		[Export ("title")]
		string Title { get; set; }

		// @property (copy, nonatomic) NSString * orderTitle;
		[Export ("orderTitle")]
		string OrderTitle { get; set; }

		// @property (copy, nonatomic) NSString * price;
		[Export ("price")]
		string Price { get; set; }

		// @property (copy, nonatomic) NSString * imageUrl;
		[Export ("imageUrl")]
		string ImageUrl { get; set; }

		// @property (copy, nonatomic) NSString * itemUrl;
		[Export ("itemUrl")]
		string ItemUrl { get; set; }

		// @property (copy, nonatomic) NSString * desc;
		[Export ("desc")]
		string Desc { get; set; }
	}

	// @interface HDQueueIdentityInfo : HDContent
	[BaseType (typeof(HDContent))]
	interface HDQueueIdentityInfo
	{
		// @property (copy, nonatomic) NSString * queueIdentity;
		[Export ("queueIdentity")]
		string QueueIdentity { get; set; }
	}

	// @interface HDRobotMenuInfo : HDContent
	[BaseType (typeof(HDContent))]
	interface HDRobotMenuInfo
	{
		// @property (copy, nonatomic) NSString * title;
		[Export ("title")]
		string Title { get; set; }

		// @property (copy, nonatomic) NSMutableArray * items;
		[Export ("items", ArgumentSemantic.Copy)]
		NSMutableArray Items { get; set; }

		// -(instancetype)initWithObject:(NSMutableDictionary *)obj;
		[Export ("initWithObject:")]
		IntPtr Constructor (NSMutableDictionary obj);
	}

	// @interface RobotMenuItem : NSObject
	[BaseType (typeof(NSObject))]
	interface RobotMenuItem
	{
		// @property (copy, nonatomic) NSString * identity;
		[Export ("identity")]
		string Identity { get; set; }

		// @property (copy, nonatomic) NSString * name;
		[Export ("name")]
		string Name { get; set; }

		// -(instancetype)initWithObject:(NSMutableDictionary *)obj;
		[Export ("initWithObject:")]
		IntPtr Constructor (NSMutableDictionary obj);
	}

	// @interface Event : HDContent
	[BaseType (typeof(HDContent))]
	interface Event
	{
		// @property (copy, nonatomic) NSString * name;
		[Export ("name")]
		string Name { get; set; }

		// @property (copy, nonatomic) NSString * obj;
		[Export ("obj")]
		string Obj { get; set; }

		// -(instancetype)initWithObject:(NSMutableDictionary *)obj;
		[Export ("initWithObject:")]
		IntPtr Constructor (NSMutableDictionary obj);
	}

	// @interface HDTransferIndication : HDCompositeContent
	[BaseType (typeof(HDCompositeContent))]
	interface HDTransferIndication
	{
		// @property (nonatomic, strong) HDAgentInfo * agentInfo;
		[Export ("agentInfo", ArgumentSemantic.Strong)]
		HDAgentInfo AgentInfo { get; set; }

		// @property (nonatomic, strong) Event * event;
		[Export ("event", ArgumentSemantic.Strong)]
		Event Event { get; set; }

		// -(instancetype)initWithContents:(NSMutableDictionary *)obj;
		[Export ("initWithContents:")]
		IntPtr Constructor (NSMutableDictionary obj);
	}

	// [Static]
	//[Verify (ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern NSString *const TYPE_EVAL_REQUEST;
		[Field ("TYPE_EVAL_REQUEST", "__Internal")]
		NSString TYPE_EVAL_REQUEST { get; }

		// extern NSString *const TYPE_EVAL_RESPONSE;
		[Field ("TYPE_EVAL_RESPONSE", "__Internal")]
		NSString TYPE_EVAL_RESPONSE { get; }

		// extern NSString *const TYPE_TRANSFER_TO_AGENT;
		[Field ("TYPE_TRANSFER_TO_AGENT", "__Internal")]
		NSString TYPE_TRANSFER_TO_AGENT { get; }
	}

	// @interface ControlType : HDContent
	[BaseType (typeof(HDContent))]
	interface ControlType
	{
		// @property (copy, nonatomic) NSString * ctrlType;
		[Export ("ctrlType")]
		string CtrlType { get; set; }

		// -(instancetype)initWithValue:(NSString *)value;
		[Export ("initWithValue:")]
		IntPtr Constructor (string value);
	}

	// @interface ControlArguments : HDContent
	[BaseType (typeof(HDContent))]
	interface ControlArguments
	{
		// @property (copy, nonatomic) NSString * identity;
		[Export ("identity")]
		string Identity { get; set; }

		// @property (copy, nonatomic) NSString * sessionId;
		[Export ("sessionId")]
		string SessionId { get; set; }

		// @property (copy, nonatomic) NSString * label;
		[Export ("label")]
		string Label { get; set; }

		// @property (copy, nonatomic) NSString * detail;
		[Export ("detail")]
		string Detail { get; set; }

		// @property (copy, nonatomic) NSString * summary;
		[Export ("summary")]
		string Summary { get; set; }

		// @property (copy, nonatomic) NSString * inviteId;
		[Export ("inviteId")]
		string InviteId { get; set; }
	}

	// @interface HDControlMessage : HDCompositeContent
	[BaseType (typeof(HDCompositeContent))]
	interface HDControlMessage
	{
		// @property (nonatomic, strong) ControlType * type;
		[Export ("type", ArgumentSemantic.Strong)]
		ControlType Type { get; set; }

		// @property (nonatomic, strong) ControlArguments * arguments;
		[Export ("arguments", ArgumentSemantic.Strong)]
		ControlArguments Arguments { get; set; }
	}

	// @interface HDMessage : NSObject
	[BaseType (typeof(NSObject))]
	interface HDMessage
	{
		// @property (copy, nonatomic) NSString * messageId;
		[Export ("messageId")]
		string MessageId { get; set; }

		// @property (nonatomic) long long timestamp __attribute__((deprecated("已过期, 请使用messageTime")));
		[Export ("timestamp")]
		long Timestamp { get; set; }

		// @property (nonatomic) long long messageTime;
		[Export ("messageTime")]
		long MessageTime { get; set; }

		// @property (nonatomic) long long localTime __attribute__((deprecated("已过期, 请使用messageTime")));
		[Export ("localTime")]
		long LocalTime { get; set; }

		// @property (nonatomic) HDMessageDirection direction;
		[Export ("direction", ArgumentSemantic.Assign)]
		HDMessageDirection Direction { get; set; }

		// @property (copy, nonatomic) NSString * conversationId;
		[Export ("conversationId")]
		string ConversationId { get; set; }

		// @property (copy, nonatomic) NSString * from;
		[Export ("from")]
		string From { get; set; }

		// @property (copy, nonatomic) NSString * to;
		[Export ("to")]
		string To { get; set; }

		// @property (nonatomic) HDMessageStatus status;
		[Export ("status", ArgumentSemantic.Assign)]
		HDMessageStatus Status { get; set; }

		// @property (nonatomic, strong) EMMessageBody * body;
		[Export ("body", ArgumentSemantic.Strong)]
		EMMessageBody Body { get; set; }

		// @property (copy, nonatomic) NSDictionary * ext;
		[Export ("ext", ArgumentSemantic.Copy)]
		NSDictionary Ext { get; set; }

		// -(id)initWithConversationID:(NSString *)aConversationId from:(NSString *)aFrom to:(NSString *)aTo body:(EMMessageBody *)aBody;
		[Export ("initWithConversationID:from:to:body:")]
		IntPtr Constructor (string aConversationId, string aFrom, string aTo, EMMessageBody aBody);

		// -(void)addAttributeDictionary:(NSDictionary *)dic;
		[Export ("addAttributeDictionary:")]
		void AddAttributeDictionary (NSDictionary dic);

		// +(instancetype)createTxtSendMessageWithContent:(NSString *)content to:(NSString *)toUserName;
		[Static]
		[Export ("createTxtSendMessageWithContent:to:")]
		HDMessage CreateTxtSendMessageWithContent (string content, string toUserName);

		// +(instancetype)createImageSendMessageWithData:(NSData *)imageData displayName:(NSString *)imageName to:(NSString *)toUserName;
		[Static]
		[Export ("createImageSendMessageWithData:displayName:to:")]
		HDMessage CreateImageSendMessageWithData (NSData imageData, string imageName, string toUserName);

		// +(instancetype)createImageSendMessageWithImage:(UIImage *)image to:(NSString *)toUserName __attribute__((deprecated("已过期, 请使用createImageSendMessageWithImage:displayName:to:")));
		[Static]
		[Export ("createImageSendMessageWithImage:to:")]
		HDMessage CreateImageSendMessageWithImage (UIImage image, string toUserName);

		// +(instancetype)createImageSendMessageWithImage:(UIImage *)image displayName:(NSString *)imageName to:(NSString *)toUserName;
		[Static]
		[Export ("createImageSendMessageWithImage:displayName:to:")]
		HDMessage CreateImageSendMessageWithImage (UIImage image, string imageName, string toUserName);

		// +(instancetype)createVoiceSendMessageWithLocalPath:(NSString *)localPath duration:(int)duration to:(NSString *)toUserName;
		[Static]
		[Export ("createVoiceSendMessageWithLocalPath:duration:to:")]
		HDMessage CreateVoiceSendMessageWithLocalPath (string localPath, int duration, string toUserName);

		// +(instancetype)createBigExpressionSendMessageWithUrl:(NSString *)url to:(NSString *)toUserName;
		[Static]
		[Export ("createBigExpressionSendMessageWithUrl:to:")]
		HDMessage CreateBigExpressionSendMessageWithUrl (string url, string toUserName);

		// +(instancetype)createLocationSendMessageWithLatitude:(double)latitude longitude:(double)longitude address:(NSString *)address to:(NSString *)toUserName;
		[Static]
		[Export ("createLocationSendMessageWithLatitude:longitude:address:to:")]
		HDMessage CreateLocationSendMessageWithLatitude (double latitude, double longitude, string address, string toUserName);

		// +(instancetype)createFileSendMessageWithLocalPath:(NSString *)localPath to:(NSString *)toUserName;
		[Static]
		[Export ("createFileSendMessageWithLocalPath:to:")]
		HDMessage CreateFileSendMessageWithLocalPath (string localPath, string toUserName);

		// +(instancetype)createFileSendMessageWithLocalPath:(NSString *)localPath displayName:(NSString *)displayName to:(NSString *)toUserName;
		[Static]
		[Export ("createFileSendMessageWithLocalPath:displayName:to:")]
		HDMessage CreateFileSendMessageWithLocalPath (string localPath, string displayName, string toUserName);

		// -(BOOL)isListened;
		[Export ("isListened")]
		//[Verify (MethodToProperty)]
		bool IsListened { get; }

		// -(void)setListened:(BOOL)isListened;
		[Export ("setListened:")]
		void SetListened (bool isListened);
	}

	// @interface HDCallManager : NSObject
	[BaseType (typeof(NSObject))]
	interface HDCallManager
	{
		// +(instancetype)shareInstance;
		[Static]
		[Export ("shareInstance")]
		HDCallManager ShareInstance ();

		// -(void)setCallOptions:(HDCallOptions *)aOptions;
		[Export ("setCallOptions:")]
		void SetCallOptions (HDCallOptions aOptions);

		// -(HDCallOptions *)getCallOptions;
		[Export ("getCallOptions")]
		//[Verify (MethodToProperty)]
		HDCallOptions CallOptions { get; }

		// -(NSArray *)hasJoinedMembers;
		[Export ("hasJoinedMembers")]
		//[Verify (MethodToProperty), Verify (StronglyTypedNSArray)]
		NSObject[] HasJoinedMembers { get; }

		// -(void)addDelegate:(id<HDCallManagerDelegate>)aDelegate delegateQueue:(dispatch_queue_t)aQueue;
		[Export ("addDelegate:delegateQueue:")]
		void AddDelegate (HDCallManagerDelegate aDelegate, [NullAllowed] DispatchQueue aQueue);

		// -(void)removeDelegate:(id<HDCallManagerDelegate>)aDelegate;
		[Export ("removeDelegate:")]
		void RemoveDelegate (HDCallManagerDelegate aDelegate);

		// -(void)acceptCallCompletion:(void (^)(id, HDError *))completion;
		[Export ("acceptCallCompletion:")]
		void AcceptCallCompletion (Action<NSObject, HDError> completion);

		// -(void)acceptCallWithNickname:(NSString *)nickname completion:(void (^)(id, HDError *))completion;
		[Export ("acceptCallWithNickname:completion:")]
		void AcceptCallWithNickname (string nickname, Action<NSObject, HDError> completion);

		// -(void)endCall;
		[Export ("endCall")]
		void EndCall ();

		// -(void)subscribeStreamId:(NSString *)streamId view:(HDCallRemoteView *)view completion:(void (^)(id, HDError *))completion;
		[Export ("subscribeStreamId:view:completion:")]
		void SubscribeStreamId (string streamId, HDCallRemoteView view, Action<NSObject, HDError> completion);

		// -(void)unSubscribeStreamId:(NSString *)streamId completion:(void (^)(id, HDError *))completion;
		[Export ("unSubscribeStreamId:completion:")]
		void UnSubscribeStreamId (string streamId, Action<NSObject, HDError> completion);

		// -(void)updateSubscribeStreamId:(NSString *)streamId view:(HDCallRemoteView *)view completion:(void (^)(id, HDError *))completion;
		[Export ("updateSubscribeStreamId:view:completion:")]
		void UpdateSubscribeStreamId (string streamId, HDCallRemoteView view, Action<NSObject, HDError> completion);

		// -(void)switchCameraPosition:(BOOL)aIsFrontCamera __attribute__((deprecated("已过期, 请使用switchCamera")));
		[Export ("switchCameraPosition:")]
		void SwitchCameraPosition (bool aIsFrontCamera);

		// -(void)switchCamera;
		[Export ("switchCamera")]
		void SwitchCamera ();

		// -(void)pauseVoice;
		[Export ("pauseVoice")]
		void PauseVoice ();

		// -(void)resumeVoice;
		[Export ("resumeVoice")]
		void ResumeVoice ();

		// -(void)pauseVideo;
		[Export ("pauseVideo")]
		void PauseVideo ();

		// -(void)resumeVideo;
		[Export ("resumeVideo")]
		void ResumeVideo ();

		// -(HDMessage *)creteVideoInviteMessageWithImId:(NSString *)aImId content:(NSString *)aContent;
		[Export ("creteVideoInviteMessageWithImId:content:")]
		HDMessage CreteVideoInviteMessageWithImId (string aImId, string aContent);

		// -(void)asyncCancelVideoInviteWithImId:(NSString *)aImId completion:(void (^)(HDError *))aCompletion;
		[Export ("asyncCancelVideoInviteWithImId:completion:")]
		void AsyncCancelVideoInviteWithImId (string aImId, Action<HDError> aCompletion);

		// -(void)sendCustomWithRemoteMemberId:(NSString *)remoteMemeberId message:(NSString *)message onDone:(void (^)(id, HDError *))block;
		[Export ("sendCustomWithRemoteMemberId:message:onDone:")]
		void SendCustomWithRemoteMemberId (string remoteMemeberId, string message, Action<NSObject, HDError> block);

		// -(void)sendCustomWithRemoteStreamId:(NSString *)remoteStreamId message:(NSString *)message onDone:(void (^)(id, HDError *))block;
		[Export ("sendCustomWithRemoteStreamId:message:onDone:")]
		void SendCustomWithRemoteStreamId (string remoteStreamId, string message, Action<NSObject, HDError> block);

		// -(void)publishWindow:(UIView *)view completion:(void (^)(id, HDError *))completion;
		[Export ("publishWindow:completion:")]
		void PublishWindow (UIView view, Action<NSObject, HDError> completion);

		// -(void)unPublishWindowWithCompletion:(void (^)(id, HDError *))completion;
		[Export ("unPublishWindowWithCompletion:")]
		void UnPublishWindowWithCompletion (Action<NSObject, HDError> completion);
	}

    partial interface IHDChatManagerDelegate {}

	// @protocol HDChatManagerDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface HDChatManagerDelegate
	{
		// @optional -(void)messagesDidReceive:(NSArray *)aMessages;
		[Export ("messagesDidReceive:")]
		//[Verify (StronglyTypedNSArray)]
		void MessagesDidReceive (NSObject[] aMessages);

		// @optional -(void)cmdMessagesDidReceive:(NSArray *)aCmdMessages;
		[Export ("cmdMessagesDidReceive:")]
		//[Verify (StronglyTypedNSArray)]
		void CmdMessagesDidReceive (NSObject[] aCmdMessages);

		// @optional -(void)messagesDidRecall:(NSArray *)recallMessageIds;
		[Export ("messagesDidRecall:")]
		//[Verify (StronglyTypedNSArray)]
		void MessagesDidRecall (NSObject[] recallMessageIds);

		// @optional -(void)messageStatusDidChange:(HDMessage *)aMessage error:(HDError *)aError;
		[Export ("messageStatusDidChange:error:")]
		void MessageStatusDidChange (HDMessage aMessage, HDError aError);

		// @optional -(void)messageAttachmentStatusDidChange:(HDMessage *)aMessage error:(HDError *)aError;
		[Export ("messageAttachmentStatusDidChange:error:")]
		void MessageAttachmentStatusDidChange (HDMessage aMessage, HDError aError);

		// @optional -(void)visitorWaitCount:(int)count;
		[Export ("visitorWaitCount:")]
		void VisitorWaitCount (int count);

		// @optional -(void)agentInputStateChange:(NSString *)content;
		[Export ("agentInputStateChange:")]
		void AgentInputStateChange (string content);
	}

	// @interface OfficialAccount : NSObject
	[BaseType (typeof(NSObject))]
	interface OfficialAccount
	{
		// @property (copy, nonatomic) NSString * officialAccountId;
		[Export ("officialAccountId")]
		string OfficialAccountId { get; set; }

		// @property (copy, nonatomic) NSString * avatarUrl __attribute__((deprecated("已过期, 请使用img")));
		[Export ("avatarUrl")]
		string AvatarUrl { get; set; }

		// @property (copy, nonatomic) NSString * img;
		[Export ("img")]
		string Img { get; set; }

		// @property (copy, nonatomic) NSString * name;
		[Export ("name")]
		string Name { get; set; }

		// @property (copy, nonatomic) NSString * type;
		[Export ("type")]
		string Type { get; set; }

		// @property (copy, nonatomic) NSString * marketingId;
		[Export ("marketingId")]
		string MarketingId { get; set; }

		// @property (copy, nonatomic) NSString * groupName;
		[Export ("groupName")]
		string GroupName { get; set; }

		// @property (copy, nonatomic) NSString * userName;
		[Export ("userName")]
		string UserName { get; set; }
	}

	// @interface HDConversation : NSObject
	[BaseType (typeof(NSObject))]
	interface HDConversation
	{
		// @property (readonly, copy, nonatomic) NSString * conversationId;
		[Export ("conversationId")]
		string ConversationId { get; }

		// @property (readonly, assign, nonatomic) HConversationType conversationType __attribute__((deprecated("已过期")));
		[Export ("conversationType", ArgumentSemantic.Assign)]
		HConversationType ConversationType { get; }

		// @property (readonly, nonatomic, strong) OfficialAccount * officialAccount;
		[Export ("officialAccount", ArgumentSemantic.Strong)]
		OfficialAccount OfficialAccount { get; }

		// @property (readonly, assign, nonatomic) int unreadMessagesCount;
		[Export ("unreadMessagesCount")]
		int UnreadMessagesCount { get; }

		// @property (nonatomic, strong) NSDictionary * ext __attribute__((deprecated("已过期")));
		[Export ("ext", ArgumentSemantic.Strong)]
		NSDictionary Ext { get; set; }

		// @property (readonly, nonatomic, strong) HDMessage * latestMessage;
		[Export ("latestMessage", ArgumentSemantic.Strong)]
		HDMessage LatestMessage { get; }

		// -(instancetype)initWithConversation:(NSString *)conversationId;
		[Export ("initWithConversation:")]
		IntPtr Constructor (string conversationId);

		// -(void)insertMessage:(HDMessage *)aMessage error:(HDError **)pError __attribute__((deprecated("已过期, 请使用addMessage")));
		[Export ("insertMessage:error:")]
		void InsertMessage (HDMessage aMessage, out HDError pError);

		// -(void)addMessage:(HDMessage *)aMessage error:(HDError **)pError;
		[Export ("addMessage:error:")]
		void AddMessage (HDMessage aMessage, out HDError pError);

		// -(void)deleteMessageWithId:(NSString *)aMessageId error:(HDError **)pError __attribute__((deprecated("已过期, 请使用removeMessageWithMessageId")));
		[Export ("deleteMessageWithId:error:")]
		void DeleteMessageWithId (string aMessageId, out HDError pError);

		// -(void)removeMessageWithMessageId:(NSString *)aMessageId error:(HDError **)pError;
		[Export ("removeMessageWithMessageId:error:")]
		void RemoveMessageWithMessageId (string aMessageId, out HDError pError);

		// -(void)deleteAllMessages:(HDError **)pError;
		[Export ("deleteAllMessages:")]
		void DeleteAllMessages (out HDError pError);

		// -(void)updateMessageChange:(HDMessage *)aMessage error:(HDError **)pError;
		[Export ("updateMessageChange:error:")]
		void UpdateMessageChange (HDMessage aMessage, out HDError pError);

		// -(void)markMessagesAsReadWithConversationId:(NSString *)conversationId error:(HDError **)pError __attribute__((deprecated("已过期")));
		[Export ("markMessagesAsReadWithConversationId:error:")]
		void MarkMessagesAsReadWithConversationId (string conversationId, out HDError pError);

		// -(void)markAllMessagesAsRead:(HDError **)pError;
		[Export ("markAllMessagesAsRead:")]
		void MarkAllMessagesAsRead (out HDError pError);

		// -(BOOL)updateConversationExtToDB __attribute__((deprecated("已过期")));
		[Export ("updateConversationExtToDB")]
		//[Verify (MethodToProperty)]
		bool UpdateConversationExtToDB { get; }

		// -(HDMessage *)loadMessageWithId:(NSString *)aMessageId error:(HDError **)pError;
		[Export ("loadMessageWithId:error:")]
		HDMessage LoadMessageWithId (string aMessageId, out HDError pError);

		// -(void)loadMessagesStartFromId:(NSString *)aMessageId count:(int)aCount searchDirection:(HDMessageSearchDirection)aDirection completion:(void (^)(NSArray *, HDError *))aCompletionBlock;
		[Export ("loadMessagesStartFromId:count:searchDirection:completion:")]
		void LoadMessagesStartFromId (string aMessageId, int aCount, HDMessageSearchDirection aDirection, Action<NSArray, HDError> aCompletionBlock);

		// -(void)loadMessagesWithType:(EMMessageBodyType)aType timestamp:(long long)aTimestamp count:(int)aCount fromUser:(NSString *)aUsername searchDirection:(HDMessageSearchDirection)aDirection completion:(void (^)(NSArray *, HDError *))aCompletionBlock __attribute__((deprecated("已过期")));
		[Export ("loadMessagesWithType:timestamp:count:fromUser:searchDirection:completion:")]
		void LoadMessagesWithType (EMMessageBodyType aType, long aTimestamp, int aCount, string aUsername, HDMessageSearchDirection aDirection, Action<NSArray, HDError> aCompletionBlock);

		// -(void)loadMessagesWithKeyword:(NSString *)aKeyword timestamp:(long long)aTimestamp count:(int)aCount fromUser:(NSString *)aSender searchDirection:(HDMessageSearchDirection)aDirection completion:(void (^)(NSArray *, HDError *))aCompletionBlock __attribute__((deprecated("已过期")));
		[Export ("loadMessagesWithKeyword:timestamp:count:fromUser:searchDirection:completion:")]
		void LoadMessagesWithKeyword (string aKeyword, long aTimestamp, int aCount, string aSender, HDMessageSearchDirection aDirection, Action<NSArray, HDError> aCompletionBlock);

		// -(void)loadMessagesFrom:(long long)aStartTimestamp to:(long long)aEndTimestamp count:(int)aCount completion:(void (^)(NSArray *, HDError *))aCompletionBlock __attribute__((deprecated("已过期")));
		[Export ("loadMessagesFrom:to:count:completion:")]
		void LoadMessagesFrom (long aStartTimestamp, long aEndTimestamp, int aCount, Action<NSArray, HDError> aCompletionBlock);

		// -(HDMessage *)lastReceivedMessage __attribute__((deprecated("已过期")));
		[Export ("lastReceivedMessage")]
		//[Verify (MethodToProperty)]
		HDMessage LastReceivedMessage { get; }
	}

	// @interface HDChatManager : NSObject
	[BaseType (typeof(NSObject))]
	interface HDChatManager
	{
		// @property (readonly, copy, nonatomic) NSString * currentConversationId __attribute__((deprecated("已过期")));
		[Export ("currentConversationId")]
		string CurrentConversationId { get; }

		// -(void)startPollingCname:(NSString *)cname __attribute__((deprecated("已过期, 请使用bindChatWithConversationId")));
		[Export ("startPollingCname:")]
		void StartPollingCname (string cname);

		// -(void)bindChatWithConversationId:(NSString *)conversationId;
		[Export ("bindChatWithConversationId:")]
		void BindChatWithConversationId (string conversationId);

		// -(void)endPolling __attribute__((deprecated("已过期, 请使用unbind")));
		[Export ("endPolling")]
		void EndPolling ();

		// -(void)unbind;
		[Export ("unbind")]
		void Unbind ();

		// -(void)addDelegate:(id<HDChatManagerDelegate>)aDelegate delegateQueue:(dispatch_queue_t)aQueue;
		[Export ("addDelegate:delegateQueue:")]
		void AddDelegate (HDChatManagerDelegate aDelegate, [NullAllowed] DispatchQueue aQueue);

		// -(void)removeDelegate:(id<HDChatManagerDelegate>)aDelegate;
		[Export ("removeDelegate:")]
		void RemoveDelegate (HDChatManagerDelegate aDelegate);

		// -(NSArray *)loadAllConversations;
		[Export ("loadAllConversations")]
		//[Verify (MethodToProperty), Verify (StronglyTypedNSArray)]
		NSObject[] LoadAllConversations { get; }

		// -(HDConversation *)getConversation:(NSString *)aConversationId;
		[Export ("getConversation:")]
		HDConversation GetConversation (string aConversationId);

		// -(BOOL)deleteConversation:(NSString *)aConversationId deleteMessages:(BOOL)aDeleteMessage;
		[Export ("deleteConversation:deleteMessages:")]
		bool DeleteConversation (string aConversationId, bool aDeleteMessage);

		// -(NSString *)getMessageAttachmentPath:(NSString *)aConversationId;
		[Export ("getMessageAttachmentPath:")]
		string GetMessageAttachmentPath (string aConversationId);

		// -(void)sendMessage:(HDMessage *)aMessage progress:(void (^)(int))aProgressBlock completion:(void (^)(HDMessage *, HDError *))aCompletionBlock;
		[Export ("sendMessage:progress:completion:")]
		void SendMessage (HDMessage aMessage, Action<int> aProgressBlock, Action<HDMessage, HDError> aCompletionBlock);

		// -(void)resendMessage:(HDMessage *)aMessage progress:(void (^)(int))aProgressCompletion completion:(void (^)(HDMessage *, HDError *))aCompletion;
		[Export ("resendMessage:progress:completion:")]
		void ResendMessage (HDMessage aMessage, Action<int> aProgressCompletion, Action<HDMessage, HDError> aCompletion);

		// -(void)updateMessage:(HDMessage *)aMessage completion:(void (^)(HDMessage *, HDError *))aCompletionBlock;
		[Export ("updateMessage:completion:")]
		void UpdateMessage (HDMessage aMessage, Action<HDMessage, HDError> aCompletionBlock);

		// -(void)getEnterpriseWelcomeWithCompletion:(void (^)(NSString *, HDError *))aCompletion;
		[Export ("getEnterpriseWelcomeWithCompletion:")]
		void GetEnterpriseWelcomeWithCompletion (Action<NSString, HDError> aCompletion);

		// -(void)asyncFetchSessionWithConversationId:(NSString *)aConversationsId sessionType:(HSessionType)aSessionType completion:(void (^)(NSArray *, HDError *))aCompletion;
		[Export ("asyncFetchSessionWithConversationId:sessionType:completion:")]
		void AsyncFetchSessionWithConversationId (string aConversationsId, HSessionType aSessionType, Action<NSArray, HDError> aCompletion);

		// -(void)downloadMessageThumbnail:(HDMessage *)aMessage progress:(void (^)(int))aProgressBlock completion:(void (^)(HDMessage *, HDError *))aCompletionBlock __attribute__((deprecated("已过期, 请使用downloadThumbnail")));
		[Export ("downloadMessageThumbnail:progress:completion:")]
		void DownloadMessageThumbnail (HDMessage aMessage, Action<int> aProgressBlock, Action<HDMessage, HDError> aCompletionBlock);

		// -(void)downloadThumbnail:(HDMessage *)aMessage progress:(void (^)(int))aProgressBlock completion:(void (^)(HDMessage *, HDError *))aCompletionBlock;
		[Export ("downloadThumbnail:progress:completion:")]
		void DownloadThumbnail (HDMessage aMessage, Action<int> aProgressBlock, Action<HDMessage, HDError> aCompletionBlock);

		// -(void)downloadAttachment:(HDMessage *)aMessage progress:(void (^)(int))aProgressBlock completion:(void (^)(HDMessage *, HDError *))aCompletionBlock;
		[Export ("downloadAttachment:progress:completion:")]
		void DownloadAttachment (HDMessage aMessage, Action<int> aProgressBlock, Action<HDMessage, HDError> aCompletionBlock);

		// -(void)downloadMessageAttachment:(HDMessage *)aMessage progress:(void (^)(int))aProgressBlock completion:(void (^)(HDMessage *, HDError *))aCompletionBlock __attribute__((deprecated("已过期, 请使用downloadAttachment")));
		[Export ("downloadMessageAttachment:progress:completion:")]
		void DownloadMessageAttachment (HDMessage aMessage, Action<int> aProgressBlock, Action<HDMessage, HDError> aCompletionBlock);

		// -(void)setMessageListened:(HDMessage *)message;
		[Export ("setMessageListened:")]
		void SetMessageListened (HDMessage message);

		// -(void)getEmojiPackageListCompletion:(void (^)(NSArray<NSDictionary *> *, HDError *))completion;
		[Export ("getEmojiPackageListCompletion:")]
		void GetEmojiPackageListCompletion (Action<NSArray<NSDictionary>, HDError> completion);

		// -(void)getEmojisWithPackageId:(NSString *)packageId completion:(void (^)(NSArray<NSDictionary *> *, HDError *))completion;
		[Export ("getEmojisWithPackageId:completion:")]
		void GetEmojisWithPackageId (string packageId, Action<NSArray<NSDictionary>, HDError> completion);

		// -(void)postContent:(NSString *)content conversationId:(NSString *)conversationId completion:(void (^)(id, HDError *))completion;
		[Export ("postContent:conversationId:completion:")]
		void PostContent (string content, string conversationId, Action<NSObject, HDError> completion);

		// -(void)asyncFetchEvaluationDegreeInfoWithCompletion:(void (^)(NSDictionary *, HDError *))aCompletion;
		[Export ("asyncFetchEvaluationDegreeInfoWithCompletion:")]
		void AsyncFetchEvaluationDegreeInfoWithCompletion (Action<NSDictionary, HDError> aCompletion);
	}

	// @interface Content (HDMessage)
	[Category]
	[BaseType (typeof(HDMessage))]
	interface HDMessage_Content
	{
		// -(void)addContent:(HDContent *)content;
		[Export ("addContent:")]
		void AddContent (HDContent content);

		// -(void)addCompositeContent:(HDCompositeContent *)content;
		[Export ("addCompositeContent:")]
		void AddCompositeContent (HDCompositeContent content);
	}

	// @interface HDOptions : NSObject
	[BaseType (typeof(NSObject))]
	interface HDOptions
	{
		// @property (nonatomic, strong) NSString * appkey;
		[Export ("appkey", ArgumentSemantic.Strong)]
		string Appkey { get; set; }

		// @property (assign, nonatomic) BOOL enableConsoleLog;
		[Export ("enableConsoleLog")]
		bool EnableConsoleLog { get; set; }

		// @property (copy, nonatomic) NSString * tenantId;
		[Export ("tenantId")]
		string TenantId { get; set; }

		// @property (nonatomic, strong) NSString * apnsCertName;
		[Export ("apnsCertName", ArgumentSemantic.Strong)]
		string ApnsCertName { get; set; }

		// @property (assign, nonatomic) BOOL enableDnsConfig;
		[Export ("enableDnsConfig")]
		bool EnableDnsConfig { get; set; }

		// @property (assign, nonatomic) int chatPort;
		[Export ("chatPort")]
		int ChatPort { get; set; }

		// @property (copy, nonatomic) NSString * chatServer;
		[Export ("chatServer")]
		string ChatServer { get; set; }

		// @property (copy, nonatomic) NSString * kefuRestServer;
		[Export ("kefuRestServer")]
		string KefuRestServer { get; set; }

		// @property (copy, nonatomic) NSString * restServer;
		[Export ("restServer")]
		string RestServer { get; set; }

		// @property (assign, nonatomic) BOOL visitorWaitCount;
		[Export ("visitorWaitCount")]
		bool VisitorWaitCount { get; set; }

		// @property (assign, nonatomic) BOOL showAgentInputState;
		[Export ("showAgentInputState")]
		bool ShowAgentInputState { get; set; }
	}

    partial interface IHDClientDelegate {}

	// @protocol HDClientDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface HDClientDelegate
	{
		// @optional -(void)connectionStateDidChange:(HConnectionState)aConnectionState;
		[Export ("connectionStateDidChange:")]
		void ConnectionStateDidChange (HConnectionState aConnectionState);

		// @optional -(void)userAccountDidLoginFromOtherDevice;
		[Export ("userAccountDidLoginFromOtherDevice")]
		void UserAccountDidLoginFromOtherDevice ();

		// @optional -(void)userAccountDidRemoveFromServer;
		[Export ("userAccountDidRemoveFromServer")]
		void UserAccountDidRemoveFromServer ();

		// @optional -(void)userDidForbidByServer;
		[Export ("userDidForbidByServer")]
		void UserDidForbidByServer ();

		// @optional -(void)userAccountDidForcedToLogout:(HDError *)aError;
		[Export ("userAccountDidForcedToLogout:")]
		void UserAccountDidForcedToLogout (HDError aError);
	}

	// @interface HDLeaveMsgManager : NSObject
	[BaseType (typeof(NSObject))]
	interface HDLeaveMsgManager
	{
		// +(instancetype)shareInstance;
		[Static]
		[Export ("shareInstance")]
		HDLeaveMsgManager ShareInstance ();

		// @property (copy, nonatomic) NSString * serverUrl __attribute__((deprecated("已过期")));
		[Export ("serverUrl")]
		string ServerUrl { get; set; }

		// -(void)getWorkStatusWithTenantId:(NSString *)tenantId completion:(void (^)(BOOL, NSError *))completion __attribute__((deprecated("已过期, 请使用getWorkStatusWithToUser")));
		[Export ("getWorkStatusWithTenantId:completion:")]
		void GetWorkStatusWithTenantId (string tenantId, Action<bool, NSError> completion);

		// -(void)getWorkStatusWithToUser:(NSString *)imServiceNumber completion:(void (^)(BOOL, NSError *))completion;
		[Export ("getWorkStatusWithToUser:completion:")]
		void GetWorkStatusWithToUser (string imServiceNumber, Action<bool, NSError> completion);

		// -(void)asyncCreateMessageWithTenantId:(NSString *)tenantId projectId:(NSString *)projectId cname:(NSString *)cname requestBody:(LeaveMsgRequestBody *)requestBody completion:(void (^)(id, NSError *))completion __attribute__((deprecated("已过期, 请使用createLeaveMsg")));
		[Export ("asyncCreateMessageWithTenantId:projectId:cname:requestBody:completion:")]
		void AsyncCreateMessageWithTenantId (string tenantId, string projectId, string cname, LeaveMsgRequestBody requestBody, Action<NSObject, NSError> completion);

		// -(void)createLeaveMsgWithProjectId:(NSString *)projectId targetUser:(NSString *)imCustomerService requestBody:(LeaveMsgRequestBody *)requestBody completion:(void (^)(id, NSError *))completion;
		[Export ("createLeaveMsgWithProjectId:targetUser:requestBody:completion:")]
		void CreateLeaveMsgWithProjectId (string projectId, string imCustomerService, LeaveMsgRequestBody requestBody, Action<NSObject, NSError> completion);

		// -(void)asyncGetLeaveMessageDetailWithTenantId:(NSString *)tenantId projectId:(NSString *)projectId cname:(NSString *)cname ticketId:(NSString *)ticketId completion:(void (^)(id, NSError *))completion __attribute__((deprecated("已过期, 请使用getLeaveMsgDetailWithProjectId")));
		[Export ("asyncGetLeaveMessageDetailWithTenantId:projectId:cname:ticketId:completion:")]
		void AsyncGetLeaveMessageDetailWithTenantId (string tenantId, string projectId, string cname, string ticketId, Action<NSObject, NSError> completion);

		// -(void)getLeaveMsgDetailWithProjectId:(NSString *)projectId targetUser:(NSString *)imCustomerService ticketId:(NSString *)ticketId completion:(void (^)(id, NSError *))completion;
		[Export ("getLeaveMsgDetailWithProjectId:targetUser:ticketId:completion:")]
		void GetLeaveMsgDetailWithProjectId (string projectId, string imCustomerService, string ticketId, Action<NSObject, NSError> completion);

		// -(void)asyncGetLeaveMessageAllCommentsWithTenantId:(NSString *)tenantId projectId:(NSString *)projectId cname:(NSString *)cname ticketId:(NSString *)ticketId page:(NSUInteger)page pageSize:(NSUInteger)pageSize completion:(void (^)(id, NSError *))completion __attribute__((deprecated("已过期, 请使用getLeaveMsgCommentsWithProjectId")));
		[Export ("asyncGetLeaveMessageAllCommentsWithTenantId:projectId:cname:ticketId:page:pageSize:completion:")]
		void AsyncGetLeaveMessageAllCommentsWithTenantId (string tenantId, string projectId, string cname, string ticketId, nuint page, nuint pageSize, Action<NSObject, NSError> completion);

		// -(void)getLeaveMsgCommentsWithProjectId:(NSString *)projectId targetUser:(NSString *)imCustomerService ticketId:(NSString *)ticketId page:(NSUInteger)page pageSize:(NSUInteger)pageSize completion:(void (^)(id, NSError *))completion;
		[Export ("getLeaveMsgCommentsWithProjectId:targetUser:ticketId:page:pageSize:completion:")]
		void GetLeaveMsgCommentsWithProjectId (string projectId, string imCustomerService, string ticketId, nuint page, nuint pageSize, Action<NSObject, NSError> completion);

		// -(void)asyncLeaveMessageCommentWithTenantId:(NSString *)tenantId projectId:(NSString *)projectId cname:(NSString *)cname ticketId:(NSString *)ticketId requestBody:(LeaveMsgRequestBody *)requestBody completion:(void (^)(id, NSError *))completion __attribute__((deprecated("已过期, 请使用createLeaveMsgCommentWithProjectId")));
		[Export ("asyncLeaveMessageCommentWithTenantId:projectId:cname:ticketId:requestBody:completion:")]
		void AsyncLeaveMessageCommentWithTenantId (string tenantId, string projectId, string cname, string ticketId, LeaveMsgRequestBody requestBody, Action<NSObject, NSError> completion);

		// -(void)createLeaveMsgCommentWithProjectId:(NSString *)projectId targetUser:(NSString *)imCustomerService ticketId:(NSString *)ticketId requestBody:(LeaveMsgRequestBody *)requestBody completion:(void (^)(id, NSError *))completion;
		[Export ("createLeaveMsgCommentWithProjectId:targetUser:ticketId:requestBody:completion:")]
		void CreateLeaveMsgCommentWithProjectId (string projectId, string imCustomerService, string ticketId, LeaveMsgRequestBody requestBody, Action<NSObject, NSError> completion);

		// -(void)asyncGetMessagesWithTenantId:(NSString *)tenantId projectId:(NSString *)projectId cname:(NSString *)cname page:(NSInteger)page pageSize:(NSInteger)pageSize completion:(void (^)(id, NSError *))completion __attribute__((deprecated("已过期, 请使用getLeaveMsgsWithProjectId")));
		[Export ("asyncGetMessagesWithTenantId:projectId:cname:page:pageSize:completion:")]
		void AsyncGetMessagesWithTenantId (string tenantId, string projectId, string cname, nint page, nint pageSize, Action<NSObject, NSError> completion);

		// -(void)getLeaveMsgsWithProjectId:(NSString *)projectId targetUser:(NSString *)imCustomerService page:(NSInteger)page pageSize:(NSInteger)pageSize completion:(void (^)(id, NSError *))completion;
		[Export ("getLeaveMsgsWithProjectId:targetUser:page:pageSize:completion:")]
		void GetLeaveMsgsWithProjectId (string projectId, string imCustomerService, nint page, nint pageSize, Action<NSObject, NSError> completion);

		// -(void)uploadWithTenantId:(NSString *)tenantId File:(NSData *)file parameters:(NSDictionary *)parameters completion:(void (^)(id, NSError *))completion __attribute__((deprecated("已过期")));
		[Export ("uploadWithTenantId:File:parameters:completion:")]
		void UploadWithTenantId (string tenantId, NSData file, NSDictionary parameters, Action<NSObject, NSError> completion);

		// -(void)downloadFileWithUrl:(NSString *)url completionHander:(void (^)(BOOL, NSURL *, NSError *))completion;
		[Export ("downloadFileWithUrl:completionHander:")]
		void DownloadFileWithUrl (string url, Action<bool, NSUrl, NSError> completion);
	}

	// @interface LeaveMsgAttachment : NSObject
	[BaseType (typeof(NSObject))]
	interface LeaveMsgAttachment
	{
		// @property (copy, nonatomic) NSString * name;
		[Export ("name")]
		string Name { get; set; }

		// @property (copy, nonatomic) NSString * url;
		[Export ("url")]
		string Url { get; set; }

		// @property (assign, nonatomic) AttachmentType type;
		[Export ("type", ArgumentSemantic.Assign)]
		AttachmentType Type { get; set; }

		// -(NSDictionary *)getContent;
		[Export ("getContent")]
		//[Verify (MethodToProperty)]
		NSDictionary Content { get; }
	}

	// @interface Creator : NSObject
	[BaseType (typeof(NSObject))]
	interface Creator
	{
		// @property (copy, nonatomic) NSString * name;
		[Export ("name")]
		string Name { get; set; }

		// @property (copy, nonatomic) NSString * avatar;
		[Export ("avatar")]
		string Avatar { get; set; }

		// @property (copy, nonatomic) NSString * email;
		[Export ("email")]
		string Email { get; set; }

		// @property (copy, nonatomic) NSString * phone;
		[Export ("phone")]
		string Phone { get; set; }

		// @property (copy, nonatomic) NSString * qq;
		[Export ("qq")]
		string Qq { get; set; }

		// @property (copy, nonatomic) NSString * companyName;
		[Export ("companyName")]
		string CompanyName { get; set; }

		// @property (copy, nonatomic) NSString * desc;
		[Export ("desc")]
		string Desc { get; set; }

		// @property (copy, nonatomic) NSString * identity;
		[Export ("identity")]
		string Identity { get; set; }

		// -(NSDictionary *)getContent;
		[Export ("getContent")]
		//[Verify (MethodToProperty)]
		NSDictionary Content { get; }
	}

	// @interface LeaveMsgRequestBody : NSObject
	[BaseType (typeof(NSObject))]
	interface LeaveMsgRequestBody
	{
		// @property (copy, nonatomic) NSString * subject;
		[Export ("subject")]
		string Subject { get; set; }

		// @property (copy, nonatomic) NSString * content;
		[Export ("content")]
		string Content { get; set; }

		// @property (assign, nonatomic) Status status;
		[Export ("status", ArgumentSemantic.Assign)]
		Status Status { get; set; }

		// @property (copy, nonatomic) NSString * priority;
		[Export ("priority")]
		string Priority { get; set; }

		// @property (copy, nonatomic) NSString * category;
		[Export ("category")]
		string Category { get; set; }

		// @property (nonatomic, strong) Creator * creator;
		[Export ("creator", ArgumentSemantic.Strong)]
		Creator Creator { get; set; }

		// @property (copy, nonatomic) NSArray<LeaveMsgAttachment *> * attachments;
		[Export ("attachments", ArgumentSemantic.Copy)]
		LeaveMsgAttachment[] Attachments { get; set; }

		// @property (copy, nonatomic) NSString * replyId;
		[Export ("replyId")]
		string ReplyId { get; set; }

		// -(NSDictionary *)getContent;
		[Export ("getContent")]
		//[Verify (MethodToProperty)]
		NSDictionary GetContent ();
	}

	// @interface HDPushOptions : NSObject
	[BaseType (typeof(NSObject))]
	interface HDPushOptions
	{
		// @property (copy, nonatomic) NSString * displayName;
		[Export ("displayName")]
		string DisplayName { get; set; }

		// @property (nonatomic) HDPushDisplayStyle displayStyle;
		[Export ("displayStyle", ArgumentSemantic.Assign)]
		HDPushDisplayStyle DisplayStyle { get; set; }

		// @property (nonatomic) HPushNoDisturbStatus noDisturbStatus;
		[Export ("noDisturbStatus", ArgumentSemantic.Assign)]
		HPushNoDisturbStatus NoDisturbStatus { get; set; }

		// @property (nonatomic) NSInteger noDisturbingStartH;
		[Export ("noDisturbingStartH")]
		nint NoDisturbingStartH { get; set; }

		// @property (nonatomic) NSInteger noDisturbingEndH;
		[Export ("noDisturbingEndH")]
		nint NoDisturbingEndH { get; set; }
	}

	// @interface HDjudgeTextMessageSubType : NSObject
	[BaseType (typeof(NSObject))]
	interface HDjudgeTextMessageSubType
	{
		// +(BOOL)isTrackMessage:(HDMessage *)message;
		[Static]
		[Export ("isTrackMessage:")]
		bool IsTrackMessage (HDMessage message);

		// +(BOOL)isOrderMessage:(HDMessage *)message;
		[Static]
		[Export ("isOrderMessage:")]
		bool IsOrderMessage (HDMessage message);

		// +(BOOL)isMenuMessage:(HDMessage *)message;
		[Static]
		[Export ("isMenuMessage:")]
		bool IsMenuMessage (HDMessage message);

		// +(BOOL)isTransferMessage:(HDMessage *)message;
		[Static]
		[Export ("isTransferMessage:")]
		bool IsTransferMessage (HDMessage message);

		// +(BOOL)isEvaluateMessage:(HDMessage *)message;
		[Static]
		[Export ("isEvaluateMessage:")]
		bool IsEvaluateMessage (HDMessage message);

		// +(BOOL)isFormMessage:(HDMessage *)message;
		[Static]
		[Export ("isFormMessage:")]
		bool IsFormMessage (HDMessage message);
	}

	// @interface HDMessageHelper : NSObject
	[BaseType (typeof(NSObject))]
	interface HDMessageHelper
	{
		// +(HDExtMsgType)getMessageExtType:(HDMessage *)message;
		[Static]
		[Export ("getMessageExtType:")]
		HDExtMsgType GetMessageExtType (HDMessage message);

		// +(BOOL)isTrackMessage:(HDMessage *)message;
		[Static]
		[Export ("isTrackMessage:")]
		bool IsTrackMessage (HDMessage message);

		// +(BOOL)isOrderMessage:(HDMessage *)message;
		[Static]
		[Export ("isOrderMessage:")]
		bool IsOrderMessage (HDMessage message);

		// +(BOOL)isMenuMessage:(HDMessage *)message;
		[Static]
		[Export ("isMenuMessage:")]
		bool IsMenuMessage (HDMessage message);

		// +(BOOL)isToCustomServiceMessage:(HDMessage *)message;
		[Static]
		[Export ("isToCustomServiceMessage:")]
		bool IsToCustomServiceMessage (HDMessage message);

		// +(BOOL)isEvaluationMessage:(HDMessage *)message;
		[Static]
		[Export ("isEvaluationMessage:")]
		bool IsEvaluationMessage (HDMessage message);

		// +(BOOL)isFormMessage:(HDMessage *)message;
		[Static]
		[Export ("isFormMessage:")]
		bool IsFormMessage (HDMessage message);

		// +(BOOL)isBigExpressionMessage:(HDMessage *)message;
		[Static]
		[Export ("isBigExpressionMessage:")]
		bool IsBigExpressionMessage (HDMessage message);
	}

	// @interface HDClient : NSObject <HDClientDelegate>
	[BaseType (typeof(NSObject))]
	partial interface HDClient : IHDClientDelegate
	{
		// @property (readonly, nonatomic, strong) NSString * currentUsername;
		[Export ("currentUsername", ArgumentSemantic.Strong)]
		string CurrentUsername { get; }

		// @property (copy, nonatomic) NSString * currentVersion __attribute__((deprecated("已过期, 请使用sdkVersion")));
		[Export ("currentVersion")]
		string CurrentVersion { get; set; }

		// @property (copy, nonatomic) NSString * sdkVersion;
		[Export ("sdkVersion")]
		string SdkVersion { get; set; }

		// @property (copy, nonatomic) NSString * imCurrentVersion __attribute__((deprecated("已过期, 请使用imSdkVersion")));
		[Export ("imCurrentVersion")]
		string ImCurrentVersion { get; set; }

		// @property (copy, nonatomic) NSString * imSdkVersion;
		[Export ("imSdkVersion")]
		string ImSdkVersion { get; set; }

		// @property (assign, nonatomic) BOOL enableVisitorWaitCount;
		[Export ("enableVisitorWaitCount")]
		bool EnableVisitorWaitCount { get; set; }

		// @property (readonly, nonatomic, strong) HDPushOptions * hdPushOptions;
		[Export ("hdPushOptions", ArgumentSemantic.Strong)]
		HDPushOptions HdPushOptions { get; }

		// @property (readonly, nonatomic, strong) HDChatManager * chat __attribute__((deprecated("已过期, 请使用chatManager")));
		[Export ("chat", ArgumentSemantic.Strong)]
		HDChatManager Chat { get; }

		// @property (readonly, nonatomic, strong) HDChatManager * chatManager;
		[Export ("chatManager", ArgumentSemantic.Strong)]
		HDChatManager ChatManager { get; }

		// @property (readonly, nonatomic) BOOL isAutoLogin __attribute__((deprecated("已过期")));
		[Export ("isAutoLogin")]
		bool IsAutoLogin { get; }

		// @property (readonly, nonatomic) BOOL isLoggedInBefore;
		[Export ("isLoggedInBefore")]
		bool IsLoggedInBefore { get; }

		// @property (readonly, nonatomic) BOOL isConnected __attribute__((deprecated("已过期")));
		[Export ("isConnected")]
		bool IsConnected { get; }

		// +(instancetype)sharedClient;
		[Static]
		[Export ("sharedClient")]
		HDClient SharedClient ();

		// -(void)addDelegate:(id<HDClientDelegate>)aDelegate delegateQueue:(dispatch_queue_t)aQueue;
		[Export ("addDelegate:delegateQueue:")]
		void AddDelegate (HDClientDelegate aDelegate, [NullAllowed] DispatchQueue aQueue);

		// -(void)removeDelegate:(id<HDClientDelegate>)aDelegate;
		[Export ("removeDelegate:")]
		void RemoveDelegate (HDClientDelegate aDelegate);

		// -(HDError *)initializeSDKWithOptions:(HDOptions *)aOptions;
		[Export ("initializeSDKWithOptions:")]
		HDError InitializeSDKWithOptions (HDOptions aOptions);

		// -(HDError *)registerWithUsername:(NSString *)aUsername password:(NSString *)aPassword;
		[Export ("registerWithUsername:password:")]
		HDError RegisterWithUsername (string aUsername, string aPassword);

		// -(HDError *)loginWithUsername:(NSString *)aUsername password:(NSString *)aPassword;
		[Export ("loginWithUsername:password:")]
		HDError LoginWithUsername_password (string aUsername, string aPassword);

		// -(HDError *)loginWithUsername:(NSString *)aUsername token:(NSString *)aToken;
		[Export ("loginWithUsername:token:")]
		HDError LoginWithUsername_token (string aUsername, string aToken);

		// -(HDError *)logout:(BOOL)bIsUnbindDeviceToken;
		[Export ("logout:")]
		HDError Logout (bool bIsUnbindDeviceToken);

		// -(HDError *)bindDeviceToken:(NSData *)aDeviceToken;
		[Export ("bindDeviceToken:")]
		HDError BindDeviceToken (NSData aDeviceToken);

		// -(HDPushOptions *)getPushOptionsFromServerWithError:(HDError **)pError;
		[Export ("getPushOptionsFromServerWithError:")]
		HDPushOptions GetPushOptionsFromServerWithError (out HDError pError);

		// -(HDError *)setApnsNickname:(NSString *)aNickname __attribute__((deprecated("已过期, 请使用setPushNickname")));
		[Export ("setApnsNickname:")]
		HDError SetApnsNickname (string aNickname);

		// -(HDError *)setPushNickname:(NSString *)aNickname;
		[Export ("setPushNickname:")]
		HDError SetPushNickname (string aNickname);

		// -(HDError *)updatePushOptionsToServer:(HDPushOptions *)HDPushOptions;
		[Export ("updatePushOptionsToServer:")]
		HDError UpdatePushOptionsToServer (HDPushOptions HDPushOptions);

		// -(void)applicationDidEnterBackground:(id)aApplication;
		[Export ("applicationDidEnterBackground:")]
		void ApplicationDidEnterBackground (NSObject aApplication);

		// -(void)applicationWillEnterForeground:(id)aApplication;
		[Export ("applicationWillEnterForeground:")]
		void ApplicationWillEnterForeground (NSObject aApplication);

		// -(HDError *)changeAppkey:(NSString *)appkey __attribute__((deprecated("已过期, 请使用changeAppKey")));
		[Export ("changeAppkey:")]
		HDError ChangeAppkey (string appkey);

		// -(HDError *)changeAppKey:(NSString *)appKey;
		[Export ("changeAppKey:")]
		HDError ChangeAppKey (string appKey);

		// -(void)changeTenantId:(NSString *)tenantId;
		[Export ("changeTenantId:")]
		void ChangeTenantId (string tenantId);

		// -(NSString *)kefuRestServer;
		[Export ("kefuRestServer")]
		//[Verify (MethodToProperty)]
		string KefuRestServer { get; }

		// -(NSString *)accessToken;
		[Export ("accessToken")]
		//[Verify (MethodToProperty)]
		string AccessToken { get; }

		// -(NSString *)getUserToken __attribute__((deprecated("已过期, 请使用accessToken")));
		[Export ("getUserToken")]
		//[Verify (MethodToProperty)]
		string UserToken { get; }

		// @property (readonly, nonatomic, strong) HDLeaveMsgManager * leaveMsgManager;
		[Export ("leaveMsgManager", ArgumentSemantic.Strong)]
		HDLeaveMsgManager LeaveMsgManager { get; }
	}

	// @interface call (HDClient)
	// [Category]
	// [BaseType (typeof(HDClient))]
	partial interface HDClient
	{
		// @property (readonly, nonatomic, strong) HDCallManager * callManager;
		[Export ("callManager", ArgumentSemantic.Strong)]
		HDCallManager CallManager { get; }

		// @property (readonly, nonatomic, strong) HDCallManager * call __attribute__((deprecated("已过期, 请使用callManager")));
		[Export ("call", ArgumentSemantic.Strong)]
		HDCallManager Call { get; }
	}

	// [Static]
	//[Verify (ConstantsInterfaceAssociation)]
	// partial interface Constants
	// {
	// 	// extern double HelpDeskVersionNumber;
	// 	[Field ("HelpDeskVersionNumber", "__Internal")]
	// 	double HelpDeskVersionNumber { get; }
    //
	// 	// extern const unsigned char [] HelpDeskVersionString;
	// 	[Field ("HelpDeskVersionString", "__Internal")]
	// 	byte[] HelpDeskVersionString { get; }
	// }
}
