// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/ApplicantJobApplication.proto
// </auto-generated>
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace CareerCloud.gRPC {
  /// <summary>
  /// The greeting service definition.
  /// </summary>
  public static partial class ApplicantJobApplicationService
  {
    static readonly string __ServiceName = "CareerCloud.gRPC.ApplicantJobApplicationService";

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static void __Helper_SerializeMessage(global::Google.Protobuf.IMessage message, grpc::SerializationContext context)
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (message is global::Google.Protobuf.IBufferMessage)
      {
        context.SetPayloadLength(message.CalculateSize());
        global::Google.Protobuf.MessageExtensions.WriteTo(message, context.GetBufferWriter());
        context.Complete();
        return;
      }
      #endif
      context.Complete(global::Google.Protobuf.MessageExtensions.ToByteArray(message));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static class __Helper_MessageCache<T>
    {
      public static readonly bool IsBufferMessage = global::System.Reflection.IntrospectionExtensions.GetTypeInfo(typeof(global::Google.Protobuf.IBufferMessage)).IsAssignableFrom(typeof(T));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static T __Helper_DeserializeMessage<T>(grpc::DeserializationContext context, global::Google.Protobuf.MessageParser<T> parser) where T : global::Google.Protobuf.IMessage<T>
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (__Helper_MessageCache<T>.IsBufferMessage)
      {
        return parser.ParseFrom(context.PayloadAsReadOnlySequence());
      }
      #endif
      return parser.ParseFrom(context.PayloadAsNewBuffer());
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::CareerCloud.gRPC.IdApplicantJobApplicationRequest> __Marshaller_CareerCloud_gRPC_IdApplicantJobApplicationRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::CareerCloud.gRPC.IdApplicantJobApplicationRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::CareerCloud.gRPC.ApplicantJobApplication> __Marshaller_CareerCloud_gRPC_ApplicantJobApplication = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::CareerCloud.gRPC.ApplicantJobApplication.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Google.Protobuf.WellKnownTypes.Empty> __Marshaller_google_protobuf_Empty = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Google.Protobuf.WellKnownTypes.Empty.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::CareerCloud.gRPC.ApplicantJobApplications> __Marshaller_CareerCloud_gRPC_ApplicantJobApplications = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::CareerCloud.gRPC.ApplicantJobApplications.Parser));

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::CareerCloud.gRPC.IdApplicantJobApplicationRequest, global::CareerCloud.gRPC.ApplicantJobApplication> __Method_GetApplicantJobApplication = new grpc::Method<global::CareerCloud.gRPC.IdApplicantJobApplicationRequest, global::CareerCloud.gRPC.ApplicantJobApplication>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetApplicantJobApplication",
        __Marshaller_CareerCloud_gRPC_IdApplicantJobApplicationRequest,
        __Marshaller_CareerCloud_gRPC_ApplicantJobApplication);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Google.Protobuf.WellKnownTypes.Empty, global::CareerCloud.gRPC.ApplicantJobApplications> __Method_GetApplicantJobApplications = new grpc::Method<global::Google.Protobuf.WellKnownTypes.Empty, global::CareerCloud.gRPC.ApplicantJobApplications>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetApplicantJobApplications",
        __Marshaller_google_protobuf_Empty,
        __Marshaller_CareerCloud_gRPC_ApplicantJobApplications);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::CareerCloud.gRPC.ApplicantJobApplications, global::Google.Protobuf.WellKnownTypes.Empty> __Method_AddApplicantJobApplications = new grpc::Method<global::CareerCloud.gRPC.ApplicantJobApplications, global::Google.Protobuf.WellKnownTypes.Empty>(
        grpc::MethodType.Unary,
        __ServiceName,
        "AddApplicantJobApplications",
        __Marshaller_CareerCloud_gRPC_ApplicantJobApplications,
        __Marshaller_google_protobuf_Empty);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::CareerCloud.gRPC.ApplicantJobApplications, global::Google.Protobuf.WellKnownTypes.Empty> __Method_UpdateApplicantJobApplications = new grpc::Method<global::CareerCloud.gRPC.ApplicantJobApplications, global::Google.Protobuf.WellKnownTypes.Empty>(
        grpc::MethodType.Unary,
        __ServiceName,
        "UpdateApplicantJobApplications",
        __Marshaller_CareerCloud_gRPC_ApplicantJobApplications,
        __Marshaller_google_protobuf_Empty);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::CareerCloud.gRPC.ApplicantJobApplications, global::Google.Protobuf.WellKnownTypes.Empty> __Method_DeleteApplicantJobApplications = new grpc::Method<global::CareerCloud.gRPC.ApplicantJobApplications, global::Google.Protobuf.WellKnownTypes.Empty>(
        grpc::MethodType.Unary,
        __ServiceName,
        "DeleteApplicantJobApplications",
        __Marshaller_CareerCloud_gRPC_ApplicantJobApplications,
        __Marshaller_google_protobuf_Empty);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::CareerCloud.gRPC.ApplicantJobApplicationReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of ApplicantJobApplicationService</summary>
    [grpc::BindServiceMethod(typeof(ApplicantJobApplicationService), "BindService")]
    public abstract partial class ApplicantJobApplicationServiceBase
    {
      /// <summary>
      /// Sends a greeting
      /// </summary>
      /// <param name="request">The request received from the client.</param>
      /// <param name="context">The context of the server-side call handler being invoked.</param>
      /// <returns>The response to send back to the client (wrapped by a task).</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::CareerCloud.gRPC.ApplicantJobApplication> GetApplicantJobApplication(global::CareerCloud.gRPC.IdApplicantJobApplicationRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::CareerCloud.gRPC.ApplicantJobApplications> GetApplicantJobApplications(global::Google.Protobuf.WellKnownTypes.Empty request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::Google.Protobuf.WellKnownTypes.Empty> AddApplicantJobApplications(global::CareerCloud.gRPC.ApplicantJobApplications request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::Google.Protobuf.WellKnownTypes.Empty> UpdateApplicantJobApplications(global::CareerCloud.gRPC.ApplicantJobApplications request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::Google.Protobuf.WellKnownTypes.Empty> DeleteApplicantJobApplications(global::CareerCloud.gRPC.ApplicantJobApplications request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static grpc::ServerServiceDefinition BindService(ApplicantJobApplicationServiceBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_GetApplicantJobApplication, serviceImpl.GetApplicantJobApplication)
          .AddMethod(__Method_GetApplicantJobApplications, serviceImpl.GetApplicantJobApplications)
          .AddMethod(__Method_AddApplicantJobApplications, serviceImpl.AddApplicantJobApplications)
          .AddMethod(__Method_UpdateApplicantJobApplications, serviceImpl.UpdateApplicantJobApplications)
          .AddMethod(__Method_DeleteApplicantJobApplications, serviceImpl.DeleteApplicantJobApplications).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the  service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static void BindService(grpc::ServiceBinderBase serviceBinder, ApplicantJobApplicationServiceBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_GetApplicantJobApplication, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::CareerCloud.gRPC.IdApplicantJobApplicationRequest, global::CareerCloud.gRPC.ApplicantJobApplication>(serviceImpl.GetApplicantJobApplication));
      serviceBinder.AddMethod(__Method_GetApplicantJobApplications, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Google.Protobuf.WellKnownTypes.Empty, global::CareerCloud.gRPC.ApplicantJobApplications>(serviceImpl.GetApplicantJobApplications));
      serviceBinder.AddMethod(__Method_AddApplicantJobApplications, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::CareerCloud.gRPC.ApplicantJobApplications, global::Google.Protobuf.WellKnownTypes.Empty>(serviceImpl.AddApplicantJobApplications));
      serviceBinder.AddMethod(__Method_UpdateApplicantJobApplications, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::CareerCloud.gRPC.ApplicantJobApplications, global::Google.Protobuf.WellKnownTypes.Empty>(serviceImpl.UpdateApplicantJobApplications));
      serviceBinder.AddMethod(__Method_DeleteApplicantJobApplications, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::CareerCloud.gRPC.ApplicantJobApplications, global::Google.Protobuf.WellKnownTypes.Empty>(serviceImpl.DeleteApplicantJobApplications));
    }

  }
}
#endregion
