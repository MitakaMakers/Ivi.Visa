using System.Runtime.Serialization;

namespace Ivi.Visa
{
    public interface IRegisterBasedSession : IVisaSession
    {
        Boolean AllowDma { get; set; }
        Int32 DestinationIncrement { get; set; }
        Int32 SourceIncrement { get; set; }
        IMemoryMap MapAddress(AddressSpace space, Int64 offset, Int64 size);
        Byte In8(AddressSpace space, Int64 sourceOffset);
        Int16 In16(AddressSpace space, Int64 sourceOffset);
        Int32 In32(AddressSpace space, Int64 sourceOffset);
        Int64 In64(AddressSpace space, Int64 sourceOffset);
        void Out8(AddressSpace space, Int64 destinationOffset, Byte value);
        void Out16(AddressSpace space, Int64 destinationOffset, Int16 value);
        void Out32(AddressSpace space, Int64 destinationOffset, Int32 value);
        void Out64(AddressSpace space, Int64 destinationOffset, Int64 value);
        Byte[] MoveIn8(AddressSpace space, Int64 sourceOffset, Int64 count);
        void MoveIn8(AddressSpace space, Int64 sourceOffset, Int64 count, Byte[] destinationBuffer, Int64 destinationIndex);
        Int16[] MoveIn16(AddressSpace space, Int64 sourceOffset, Int64 count);
        void MoveIn16(AddressSpace space, Int64 sourceOffset, Int64 count, Int16[] destinationBuffer, Int64 destinationIndex);
        Int32[] MoveIn32(AddressSpace space, Int64 sourceOffset, Int64 count);
        void MoveIn32(AddressSpace space, Int64 sourceOffset, Int64 count, Int32[] destinationBuffer, Int64 destinationIndex);
        Int64[] MoveIn64(AddressSpace space, Int64 sourceOffset, Int64 count);
        void MoveIn64(AddressSpace space, Int64 sourceOffset, Int64 count, Int64[] destinationBuffer, Int64 destinationIndex);
        void MoveOut8(AddressSpace space, Int64 destinationOffset, Byte[] sourceBuffer);
        void MoveOut8(AddressSpace space, Int64 destinationOffset, Byte[] sourceBuffer, Int64 sourceIndex, Int64 count);
        void MoveOut16(AddressSpace space, Int64 destinationOffset, Int16[] sourceBuffer);
        void MoveOut16(AddressSpace space, Int64 destinationOffset, Int16[] sourceBuffer, Int64 sourceIndex, Int64 count);
        void MoveOut32(AddressSpace space, Int64 destinationOffset, Int32[] sourceBuffer);
        void MoveOut32(AddressSpace space, Int64 destinationOffset, Int32[] sourceBuffer, Int64 sourceIndex, Int64 count);
        void MoveOut64(AddressSpace space, Int64 destinationOffset, Int64[] sourceBuffer);
        void MoveOut64(AddressSpace space, Int64 destinationOffset, Int64[] sourceBuffer, Int64 sourceIndex, Int64 count);
    }
    public interface IMemoryMap : IDisposable
    {
        AddressSpace AddressSpace { get; }
        Int64 BaseAddress { get; }
        Int64 Size { get; }
        IntPtr VirtualAddress { get; }
        Byte Peek8(Int64 offset);
        Int16 Peek16(Int64 offset);
        Int32 Peek32(Int64 offset);
        Int64 Peek64(Int64 offset);
        void Poke8(Int64 offset, Byte value);
        void Poke16(Int64 offset, Int16 value);
        void Poke32(Int64 offset, Int32 value);
        void Poke64(Int64 offset, Int64 value);
    }
}