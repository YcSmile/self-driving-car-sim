// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: LiDarPoints.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace LiDarMsg {

  /// <summary>Holder for reflection information generated from LiDarPoints.proto</summary>
  public static partial class LiDarPointsReflection {

    #region Descriptor
    /// <summary>File descriptor for LiDarPoints.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static LiDarPointsReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "ChFMaURhclBvaW50cy5wcm90bxIITGlEYXJNc2ciQQoFTGFzZXISDAoETGFJ",
            "ZBgBIAEoBRIOCgZSYWRpdXMYAiABKAISDQoFUGl0Y2gYAyABKAISCwoDWWF3",
            "GAQgASgCIj8KCUxpRGFyTGluZRIOCgZMaW5lSUQYASABKAUSIgoJTGFzZXJE",
            "YXRhGAIgAygLMg8uTGlEYXJNc2cuTGFzZXIiMgoJTGlEYXJEYXRhEiUKCExp",
            "bmVEYXRhGAEgAygLMhMuTGlEYXJNc2cuTGlEYXJMaW5lQguqAghMaURhck1z",
            "Z2IGcHJvdG8z"));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::LiDarMsg.Laser), global::LiDarMsg.Laser.Parser, new[]{ "LaId", "Radius", "Pitch", "Yaw" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::LiDarMsg.LiDarLine), global::LiDarMsg.LiDarLine.Parser, new[]{ "LineID", "LaserData" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::LiDarMsg.LiDarData), global::LiDarMsg.LiDarData.Parser, new[]{ "LineData" }, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  /// <summary>
  /// 每一个点
  /// </summary>
  public sealed partial class Laser : pb::IMessage<Laser> {
    private static readonly pb::MessageParser<Laser> _parser = new pb::MessageParser<Laser>(() => new Laser());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<Laser> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::LiDarMsg.LiDarPointsReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Laser() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Laser(Laser other) : this() {
      laId_ = other.laId_;
      radius_ = other.radius_;
      pitch_ = other.pitch_;
      yaw_ = other.yaw_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Laser Clone() {
      return new Laser(this);
    }

    /// <summary>Field number for the "LaId" field.</summary>
    public const int LaIdFieldNumber = 1;
    private int laId_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int LaId {
      get { return laId_; }
      set {
        laId_ = value;
      }
    }

    /// <summary>Field number for the "Radius" field.</summary>
    public const int RadiusFieldNumber = 2;
    private float radius_;
    /// <summary>
    /// 半径
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public float Radius {
      get { return radius_; }
      set {
        radius_ = value;
      }
    }

    /// <summary>Field number for the "Pitch" field.</summary>
    public const int PitchFieldNumber = 3;
    private float pitch_;
    /// <summary>
    /// 俯仰角
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public float Pitch {
      get { return pitch_; }
      set {
        pitch_ = value;
      }
    }

    /// <summary>Field number for the "Yaw" field.</summary>
    public const int YawFieldNumber = 4;
    private float yaw_;
    /// <summary>
    /// 航向角
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public float Yaw {
      get { return yaw_; }
      set {
        yaw_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as Laser);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(Laser other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (LaId != other.LaId) return false;
      if (!pbc::ProtobufEqualityComparers.BitwiseSingleEqualityComparer.Equals(Radius, other.Radius)) return false;
      if (!pbc::ProtobufEqualityComparers.BitwiseSingleEqualityComparer.Equals(Pitch, other.Pitch)) return false;
      if (!pbc::ProtobufEqualityComparers.BitwiseSingleEqualityComparer.Equals(Yaw, other.Yaw)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (LaId != 0) hash ^= LaId.GetHashCode();
      if (Radius != 0F) hash ^= pbc::ProtobufEqualityComparers.BitwiseSingleEqualityComparer.GetHashCode(Radius);
      if (Pitch != 0F) hash ^= pbc::ProtobufEqualityComparers.BitwiseSingleEqualityComparer.GetHashCode(Pitch);
      if (Yaw != 0F) hash ^= pbc::ProtobufEqualityComparers.BitwiseSingleEqualityComparer.GetHashCode(Yaw);
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (LaId != 0) {
        output.WriteRawTag(8);
        output.WriteInt32(LaId);
      }
      if (Radius != 0F) {
        output.WriteRawTag(21);
        output.WriteFloat(Radius);
      }
      if (Pitch != 0F) {
        output.WriteRawTag(29);
        output.WriteFloat(Pitch);
      }
      if (Yaw != 0F) {
        output.WriteRawTag(37);
        output.WriteFloat(Yaw);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (LaId != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(LaId);
      }
      if (Radius != 0F) {
        size += 1 + 4;
      }
      if (Pitch != 0F) {
        size += 1 + 4;
      }
      if (Yaw != 0F) {
        size += 1 + 4;
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(Laser other) {
      if (other == null) {
        return;
      }
      if (other.LaId != 0) {
        LaId = other.LaId;
      }
      if (other.Radius != 0F) {
        Radius = other.Radius;
      }
      if (other.Pitch != 0F) {
        Pitch = other.Pitch;
      }
      if (other.Yaw != 0F) {
        Yaw = other.Yaw;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 8: {
            LaId = input.ReadInt32();
            break;
          }
          case 21: {
            Radius = input.ReadFloat();
            break;
          }
          case 29: {
            Pitch = input.ReadFloat();
            break;
          }
          case 37: {
            Yaw = input.ReadFloat();
            break;
          }
        }
      }
    }

  }

  /// <summary>
  /// 每一列
  /// </summary>
  public sealed partial class LiDarLine : pb::IMessage<LiDarLine> {
    private static readonly pb::MessageParser<LiDarLine> _parser = new pb::MessageParser<LiDarLine>(() => new LiDarLine());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<LiDarLine> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::LiDarMsg.LiDarPointsReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public LiDarLine() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public LiDarLine(LiDarLine other) : this() {
      lineID_ = other.lineID_;
      laserData_ = other.laserData_.Clone();
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public LiDarLine Clone() {
      return new LiDarLine(this);
    }

    /// <summary>Field number for the "LineID" field.</summary>
    public const int LineIDFieldNumber = 1;
    private int lineID_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int LineID {
      get { return lineID_; }
      set {
        lineID_ = value;
      }
    }

    /// <summary>Field number for the "LaserData" field.</summary>
    public const int LaserDataFieldNumber = 2;
    private static readonly pb::FieldCodec<global::LiDarMsg.Laser> _repeated_laserData_codec
        = pb::FieldCodec.ForMessage(18, global::LiDarMsg.Laser.Parser);
    private readonly pbc::RepeatedField<global::LiDarMsg.Laser> laserData_ = new pbc::RepeatedField<global::LiDarMsg.Laser>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<global::LiDarMsg.Laser> LaserData {
      get { return laserData_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as LiDarLine);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(LiDarLine other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (LineID != other.LineID) return false;
      if(!laserData_.Equals(other.laserData_)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (LineID != 0) hash ^= LineID.GetHashCode();
      hash ^= laserData_.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (LineID != 0) {
        output.WriteRawTag(8);
        output.WriteInt32(LineID);
      }
      laserData_.WriteTo(output, _repeated_laserData_codec);
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (LineID != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(LineID);
      }
      size += laserData_.CalculateSize(_repeated_laserData_codec);
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(LiDarLine other) {
      if (other == null) {
        return;
      }
      if (other.LineID != 0) {
        LineID = other.LineID;
      }
      laserData_.Add(other.laserData_);
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 8: {
            LineID = input.ReadInt32();
            break;
          }
          case 18: {
            laserData_.AddEntriesFrom(input, _repeated_laserData_codec);
            break;
          }
        }
      }
    }

  }

  /// <summary>
  /// 全部数据
  /// </summary>
  public sealed partial class LiDarData : pb::IMessage<LiDarData> {
    private static readonly pb::MessageParser<LiDarData> _parser = new pb::MessageParser<LiDarData>(() => new LiDarData());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<LiDarData> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::LiDarMsg.LiDarPointsReflection.Descriptor.MessageTypes[2]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public LiDarData() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public LiDarData(LiDarData other) : this() {
      lineData_ = other.lineData_.Clone();
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public LiDarData Clone() {
      return new LiDarData(this);
    }

    /// <summary>Field number for the "LineData" field.</summary>
    public const int LineDataFieldNumber = 1;
    private static readonly pb::FieldCodec<global::LiDarMsg.LiDarLine> _repeated_lineData_codec
        = pb::FieldCodec.ForMessage(10, global::LiDarMsg.LiDarLine.Parser);
    private readonly pbc::RepeatedField<global::LiDarMsg.LiDarLine> lineData_ = new pbc::RepeatedField<global::LiDarMsg.LiDarLine>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<global::LiDarMsg.LiDarLine> LineData {
      get { return lineData_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as LiDarData);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(LiDarData other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if(!lineData_.Equals(other.lineData_)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      hash ^= lineData_.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      lineData_.WriteTo(output, _repeated_lineData_codec);
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      size += lineData_.CalculateSize(_repeated_lineData_codec);
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(LiDarData other) {
      if (other == null) {
        return;
      }
      lineData_.Add(other.lineData_);
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            lineData_.AddEntriesFrom(input, _repeated_lineData_codec);
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code