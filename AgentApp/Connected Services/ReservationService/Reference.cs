﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     //
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using AgentApp.Models;
using AgentDB;
using System;
using System.Collections.Generic;

namespace ReservationService
{


    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.ServiceModel.ServiceContractAttribute(Namespace = "", ConfigurationName = "ReservationService.ReservationPort")]
    public interface ReservationPort
    {

        [System.ServiceModel.OperationContractAttribute(Action = "", ReplyAction = "*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults = true)]
        System.Threading.Tasks.Task<addMessageResponse1> addMessageAsync(addMessageRequest1 request);

        [System.ServiceModel.OperationContractAttribute(Action = "", ReplyAction = "*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults = true)]
        System.Threading.Tasks.Task<getReservationResponse> getReservationAsync(getReservationRequest1 request);

        [System.ServiceModel.OperationContractAttribute(Action = "", ReplyAction = "*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults = true)]
        System.Threading.Tasks.Task<setRealizedResponse1> setRealizedAsync(setRealizedRequest1 request);
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "")]
    public partial class addMessageRequest
    {

        private long reservationIdField;

        private Message messageField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public long reservationId
        {
            get
            {
                return this.reservationIdField;
            }
            set
            {
                this.reservationIdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "", Order = 1)]
        public Message Message
        {
            get
            {
                return this.messageField;
            }
            set
            {
                this.messageField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "")]
    public partial class Message
    {

        private string contentField;

        private System.DateTime timestampField;

        private DirectionEnum directionField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute()]
        public string content
        {
            get
            {
                return this.contentField;
            }
            set
            {
                this.contentField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute()]
        public System.DateTime timestamp
        {
            get
            {
                return this.timestampField;
            }
            set
            {
                this.timestampField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute()]
        public DirectionEnum direction
        {
            get
            {
                return this.directionField;
            }
            set
            {
                this.directionField = (DirectionEnum)value;
            }
        }

        public AgentApp.Models.Message CreateMessage()
        {
            AgentApp.Models.Message message = new AgentApp.Models.Message();

            message.Content = this.content;
            if (this.direction.Equals(DirectionEnum.USER_TO_AGENT))
            {
                message.Direction = AgentApp.Models.DirectionEnum.USER_TO_AGENT;
            }
            else
            {
                message.Direction = AgentApp.Models.DirectionEnum.AGENT_TO_USER;
            }

            message.Timestamp = this.timestamp;

            return message;
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "")]
    public enum DirectionEnum
    {

        /// <remarks/>
        AGENT_TO_USER,

        /// <remarks/>
        USER_TO_AGENT,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "")]
    public partial class addMessageResponse
    {

        private Message messageField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "", Order = 0)]
        public Message Message
        {
            get
            {
                return this.messageField;
            }
            set
            {
                this.messageField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "")]
    public partial class Reservation
    {
        private long idField;

        private long accommodationIdField;

        private long userIdField;

        private System.DateTime startDateField;

        private System.DateTime endDateField;

        private bool realizedField;

        private ReservationRating reservationRatingField;

        private Message[] messageField;

        [System.Xml.Serialization.XmlElementAttribute()]
        public long id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute()]
        public long accommodationId
        {
            get
            {
                return this.accommodationIdField;
            }
            set
            {
                this.accommodationIdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute()]
        public long userId
        {
            get
            {
                return this.userIdField;
            }
            set
            {
                this.userIdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
        public System.DateTime startDate
        {
            get
            {
                return this.startDateField;
            }
            set
            {
                this.startDateField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
        public System.DateTime endDate
        {
            get
            {
                return this.endDateField;
            }
            set
            {
                this.endDateField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute()]
        public bool realized
        {
            get
            {
                return this.realizedField;
            }
            set
            {
                this.realizedField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute()]
        public ReservationRating ReservationRating
        {
            get
            {
                return this.reservationRatingField;
            }
            set
            {
                this.reservationRatingField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Message")]
        public Message[] Message
        {
            get
            {
                return this.messageField;
            }
            set
            {
                this.messageField = value;
            }
        }

        public AgentApp.Models.Reservation CreateReservation()
        {

            AgentApp.Models.Reservation resDTO = new AgentApp.Models.Reservation();

            resDTO.Accommodation = new Accommodation();
            resDTO.Id = this.idField;
            resDTO.EndDate = this.endDateField;
            resDTO.StartDate = this.startDateField;
            resDTO.UserID = this.userIdField;
            if(this.reservationRatingField != null)
            {
                resDTO.ReservationRating = this.reservationRatingField.CreateReservationRating();
            }
            resDTO.Realized = this.realizedField;
            resDTO.Messages = new List<AgentApp.Models.Message>();
            if(this.messageField != null)
            {
                for(int i = 0; i < this.messageField.Length; ++i) 
                {
                    resDTO.Messages.Add(this.messageField[i].CreateMessage());
                }
            }

            return resDTO;
        }

    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "")]
    public partial class ReservationRating
    {

        private int ratingField;

        private string commentField;

        private System.DateTime timestampField;

        private bool publishedField;

        public ReservationRating()
        {
            this.publishedField = false;
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute()]
        public int rating
        {
            get
            {
                return this.ratingField;
            }
            set
            {
                this.ratingField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute()]
        public string comment
        {
            get
            {
                return this.commentField;
            }
            set
            {
                this.commentField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute()]
        public System.DateTime timestamp
        {
            get
            {
                return this.timestampField;
            }
            set
            {
                this.timestampField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute()]
        public bool published
        {
            get
            {
                return this.publishedField;
            }
            set
            {
                this.publishedField = value;
            }
        }

        public AgentApp.Models.ReservationRating CreateReservationRating()
        {
            AgentApp.Models.ReservationRating resRating = new AgentApp.Models.ReservationRating();

            resRating.Published = this.publishedField;
            resRating.Rating = this.ratingField;
            resRating.Timestamp = this.timestampField;
            resRating.Comment = this.commentField;

            return resRating;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class addMessageRequest1
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "", Order = 0)]
        public ReservationService.addMessageRequest addMessageRequest;

        public addMessageRequest1()
        {
        }

        public addMessageRequest1(ReservationService.addMessageRequest addMessageRequest)
        {
            this.addMessageRequest = addMessageRequest;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class addMessageResponse1
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "", Order = 0)]
        public ReservationService.addMessageResponse addMessageResponse;

        public addMessageResponse1()
        {
        }

        public addMessageResponse1(ReservationService.addMessageResponse addMessageResponse)
        {
            this.addMessageResponse = addMessageResponse;
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "")]
    public partial class getReservationRequest
    {

        private long accommodationIdField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public long accommodationId
        {
            get
            {
                return this.accommodationIdField;
            }
            set
            {
                this.accommodationIdField = value;
            }
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class getReservationRequest1
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "", Order = 0)]
        public getReservationRequest getReservationRequest;

        public getReservationRequest1()
        {
        }

        public getReservationRequest1(getReservationRequest getReservationRequest)
        {
            this.getReservationRequest = getReservationRequest;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class getReservationResponse
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Name = "getReservationResponse", Namespace = "", Order = 0)]
        [System.Xml.Serialization.XmlArrayItemAttribute("Reservation", Namespace = "", IsNullable = false)]
        public ReservationService.Reservation[] getReservationResponse1;

        public getReservationResponse()
        {
        }

        public getReservationResponse(ReservationService.Reservation[] getReservationResponse1)
        {
            this.getReservationResponse1 = getReservationResponse1;
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "")]
    public partial class setRealizedRequest
    {

        private long reservationIdField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public long reservationId
        {
            get
            {
                return this.reservationIdField;
            }
            set
            {
                this.reservationIdField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "")]
    public partial class setRealizedResponse
    {

        private Reservation reservationField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "", Order = 0)]
        public Reservation Reservation
        {
            get
            {
                return this.reservationField;
            }
            set
            {
                this.reservationField = value;
            }
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class setRealizedRequest1
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "", Order = 0)]
        public setRealizedRequest setRealizedRequest;

        public setRealizedRequest1()
        {
        }

        public setRealizedRequest1(setRealizedRequest setRealizedRequest)
        {
            this.setRealizedRequest = setRealizedRequest;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class setRealizedResponse1
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "", Order = 0)]
        public setRealizedResponse setRealizedResponse;

        public setRealizedResponse1()
        {
        }

        public setRealizedResponse1(setRealizedResponse setRealizedResponse)
        {
            this.setRealizedResponse = setRealizedResponse;
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    public interface ReservationPortChannel : ReservationService.ReservationPort, System.ServiceModel.IClientChannel
    {
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    public partial class ReservationPortClient : System.ServiceModel.ClientBase<ReservationService.ReservationPort>, ReservationService.ReservationPort
    {

        /// <summary>
        /// Implement this partial method to configure the service endpoint.
        /// </summary>
        /// <param name="serviceEndpoint">The endpoint to configure</param>
        /// <param name="clientCredentials">The client credentials</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);

        public ReservationPortClient() :
                base(ReservationPortClient.GetDefaultBinding(), ReservationPortClient.GetDefaultEndpointAddress())
        {
            this.Endpoint.Name = EndpointConfiguration.ReservationPortSoap11.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }

        public ReservationPortClient(EndpointConfiguration endpointConfiguration) :
                base(ReservationPortClient.GetBindingForEndpoint(endpointConfiguration), ReservationPortClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }

        public ReservationPortClient(EndpointConfiguration endpointConfiguration, string remoteAddress) :
                base(ReservationPortClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }

        public ReservationPortClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) :
                base(ReservationPortClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }

        public ReservationPortClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) :
                base(binding, remoteAddress)
        {
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<addMessageResponse1> ReservationService.ReservationPort.addMessageAsync(addMessageRequest1 request)
        {
            return base.Channel.addMessageAsync(request);
        }

        public System.Threading.Tasks.Task<addMessageResponse1> addMessageAsync(ReservationService.addMessageRequest addMessageRequest)
        {
            addMessageRequest1 inValue = new addMessageRequest1();
            inValue.addMessageRequest = addMessageRequest;
            return ((ReservationService.ReservationPort)(this)).addMessageAsync(inValue);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<getReservationResponse> ReservationService.ReservationPort.getReservationAsync(getReservationRequest1 request)
        {
            return base.Channel.getReservationAsync(request);
        }

        public System.Threading.Tasks.Task<getReservationResponse> getReservationAsync(getReservationRequest getReservationRequest)
        {
            getReservationRequest1 inValue = new getReservationRequest1();
            inValue.getReservationRequest = getReservationRequest;
            return ((ReservationService.ReservationPort)(this)).getReservationAsync(inValue);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<setRealizedResponse1> ReservationService.ReservationPort.setRealizedAsync(setRealizedRequest1 request)
        {
            return base.Channel.setRealizedAsync(request);
        }

        public System.Threading.Tasks.Task<setRealizedResponse1> setRealizedAsync(setRealizedRequest setRealizedRequest)
        {
            setRealizedRequest1 inValue = new setRealizedRequest1();
            inValue.setRealizedRequest = setRealizedRequest;
            return ((ReservationService.ReservationPort)(this)).setRealizedAsync(inValue);
        }

        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }

        public virtual System.Threading.Tasks.Task CloseAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginClose(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndClose));
        }

        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.ReservationPortSoap11))
            {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }

        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.ReservationPortSoap11))
            {
                return new System.ServiceModel.EndpointAddress("http://localhost:8084/ws");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }

        private static System.ServiceModel.Channels.Binding GetDefaultBinding()
        {
            return ReservationPortClient.GetBindingForEndpoint(EndpointConfiguration.ReservationPortSoap11);
        }

        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress()
        {
            return ReservationPortClient.GetEndpointAddress(EndpointConfiguration.ReservationPortSoap11);
        }

        public enum EndpointConfiguration
        {

            ReservationPortSoap11,
        }
    }
}
