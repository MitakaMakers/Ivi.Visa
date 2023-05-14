using System.Text.RegularExpressions;

namespace Ivi.Visa
{
    public class IMessage
    {
        public int Timeout { get; set; }
    }
    public sealed class HardwareInterface : IEquatable<HardwareInterface>
    {
        public Int16 Number { get; private set; }
        public String ResourceClass { get; private set; } = String.Empty;
        public Int32 Type { get; private set; }
        public HardwareInterface(Int32 type, Int16 number, String resourceClass) {}
        public static Boolean operator ==(HardwareInterface intf1, HardwareInterface intf2)
        {
            throw new NotImplementedException();
        }
        public static Boolean operator !=(HardwareInterface intf1, HardwareInterface intf2)
        {
            throw new NotImplementedException();
        }
        public override Boolean Equals(object? o)
        {
            throw new NotImplementedException();
        }
        public Boolean Equals(HardwareInterface? other)
        {
            throw new NotImplementedException();
        }
        public override int GetHashCode() { return 0; }
    }
    public sealed class VisaImplementation : IEquatable<VisaImplementation>
    {
        public ApiType ApiType { get; private set; }
        public String Comments { get; private set; } = String.Empty;    
        public Boolean Enabled { get; set; }
        public String FriendlyName { get; private set; } = String.Empty;
        public Guid HandlerId { get; private set; }
        public String Location { get; private set; } = String.Empty;
        public Int32 ResourceManufacturerId { get; private set; }
        public VisaImplementation(Guid handlerId, Int32 resourceManufacturerId, String location, String friendlyName, String comments, ApiType apiType) {}
        public static Boolean operator ==(VisaImplementation visa1, VisaImplementation visa2)
        {
            throw new NotImplementedException();
        }
        public static Boolean operator !=(VisaImplementation visa1, VisaImplementation visa2)
        {
            throw new NotImplementedException();
        }
        public override Boolean Equals(object? o)
        {
            throw new NotImplementedException();
        }
        public Boolean Equals(VisaImplementation? other)
        {
            throw new NotImplementedException();
        }
        public override int GetHashCode() { return 0; }
    }
    public sealed class ConflictManager : IDisposable
    {
        public Boolean StoreConflictsOnly { get; set; }
        public String ConflictFilePath { get; } = String.Empty;
        public Boolean IsDirty { get; }
        public ConflictManager() {}
        ~ConflictManager() {}
        public void Dispose() {}
        public void ClearTable() {}
        public void CreateHandler(HardwareInterface intf, VisaImplementation visa, HandlerType type) {}
        public void CreateHandler(HardwareInterface intf, VisaImplementation visa, HandlerType type, String comments) {}
        public void FlushConflictFile(FlushBehavior behavior) {}
        public void FlushConflictFile(FlushBehavior behavior, out Boolean fileOnDiskWasNewer)
        {
            throw new NotImplementedException();
        }
        public VisaImplementation GetChosenHandler(ApiType apiType, HardwareInterface intf)
        {
            throw new NotImplementedException();
        }
        public VisaImplementation GetChosenHandler(ApiType apiType, HardwareInterface intf, out HandlerType handlerType)
        {
            throw new NotImplementedException();
        }
        public List<VisaImplementation> GetHandlers(ApiType apiType, HardwareInterface intf)
        {
            throw new NotImplementedException();
        }
        public List<VisaImplementation> GetInstalledVisas(ApiType apiType)
        {
            throw new NotImplementedException();
        }
        public List<HardwareInterface> GetInterfaces(ApiType apiType)
        {
            throw new NotImplementedException();
        }
        public VisaImplementation GetPreferredVisa(ApiType apiType)
        {
            throw new NotImplementedException();
        }
        public void ReloadFile() {}
        public void RemoveHandler(HardwareInterface intf, VisaImplementation visa) {}
        public void RemoveHandlers(ApiType apiType) {}
        public void RemoveHandlers(ApiType apiType, HardwareInterface intf) {}
        public void RemoveHandlers(VisaImplementation visa) {}
        public void SetPreferredVisa(VisaImplementation visa) {}
    }
    public interface IResourceManager : IDisposable
    {
        IEnumerable<String> Find(String pattern);
        ParseResult Parse(String resourceName);
        IVisaSession Open(String resourceName);
        IVisaSession Open(String resourceName, AccessMode accessMode, Int32 timeoutMilliseconds);
        IVisaSession Open(String resourceName, AccessMode accessModes, Int32 timeoutMilliseconds, out ResourceOpenStatus openStatus);
        String ManufacturerName { get; }
        Int16 ManufacturerId { get; }
        Version ImplementationVersion { get; }
        Version SpecificationVersion { get; }
    }

    public class ParseResult
    {
        public String OriginalResourceName { get; private set; } = String.Empty;
        public HardwareInterfaceType InterfaceType { get; private set; }
        public Int32 InterfaceNumber { get; private set; }
        public String ResourceClass { get; private set; } = String.Empty;
        public String ExpandedUnaliasedName { get; private set; } = String.Empty;
        public String AliasIfExists { get; private set; } = String.Empty;
        public ParseResult(String originalResourceName, HardwareInterfaceType interfaceType, Int16 interfaceNumber, String resourceClass, String expandedUnaliasedName, String aliasIfExists) { }
        public static Boolean operator ==(ParseResult parse1, ParseResult parse2) { return true; }
        public static Boolean operator !=(ParseResult parse1, ParseResult parse2) { return true; }
        public override bool Equals(object? o) { return true; }
        public override int GetHashCode() { return 0; }
    }
    public static class GlobalResourceManager
    {
        public static IEnumerable<String> Find()
        {
            throw new NotImplementedException();
        }
        public static IEnumerable<String> Find(String pattern)
        {
            throw new NotImplementedException();
        }
        public static ParseResult Parse(String resourceName)
        {
            throw new NotImplementedException();
        }
        public static Boolean TryParse(String resourceName, out ParseResult result)
        {
            throw new NotImplementedException();
        }
        public static IVisaSession Open(String resourceName)
        {
            return Open(resourceName, AccessMode.None, 10 * 1000);
        }
        public static IVisaSession Open(String resourceName, AccessMode accessMode, Int32 timeoutMilliseconds)
        {
            ResourceOpenStatus openStatus;
            return Open(resourceName, accessMode, timeoutMilliseconds, out openStatus);
        }
        public static IVisaSession Open(String resourceName, AccessMode accessModes, Int32 timeoutMilliseconds, out ResourceOpenStatus openStatus)
        {
            IVisaSession sesn = new VisaNullSession();
            openStatus = ResourceOpenStatus.ConfigurationNotLoaded;

            string[] token = Regex.Split(resourceName, "::");
            if (Regex.IsMatch(token[0], "^[Tt][Cc][Pp][Ii][Pp]"))
            {
                if (2 == token.Length)
                {
                    sesn = new Vxi11Session(token[1], "inst0");
                    openStatus = ResourceOpenStatus.Success;
                }
                else if (3 == token.Length)
                {
                    if (Regex.IsMatch(token[2], "[Hh][Ii][Ss][Ll][Ii][Pp]"))
                    {
                    }
                    else
                    {
                        sesn = new Vxi11Session(token[1], token[2]);
                        openStatus = ResourceOpenStatus.Success;
                    }
                }
                else if (4 == token.Length)
                {
                    if (Regex.IsMatch(token[3], "[Ii][Nn][Ss][Tt][Rr]"))
                    {
                        if (Regex.IsMatch(token[2], "[Hh][Ii][Ss][Ll][Ii][Pp]"))
                        {
                        }
                        else
                        {
                            sesn = new Vxi11Session(token[1], token[2]);
                            openStatus = ResourceOpenStatus.Success;
                        }
                    }
                    else if (Regex.IsMatch(token[3], "[Ss][Oo][Cc][Kk][Ee][Tt]"))
                    {
                        sesn = new TcpipSocketSession(token[1], token[2]);
                        openStatus = ResourceOpenStatus.Success;
                    }
                }
            }
            else
            {
                throw new NotImplementedException();
            }
            return sesn;
        }
        public static String ManufacturerName { get; } = String.Empty;
        public static Int16 ManufacturerId { get; }
        public static Version ImplementationVersion { get; } = Environment.Version;
        public static Version SpecificationVersion { get; } = Environment.Version;
    }
    public class ResourceManager : IResourceManager
    {
        private bool disposedValue;

        public string ManufacturerName => throw new NotImplementedException();

        public short ManufacturerId => throw new NotImplementedException();

        public Version ImplementationVersion => throw new NotImplementedException();

        public Version SpecificationVersion => throw new NotImplementedException();

        public IEnumerable<string> Find(string pattern)
        {
            throw new NotImplementedException();
        }

        public IMessage Open(string str, AccessMode mode, int a, string b)
        {
            return new IMessage();
        }

        public IVisaSession Open(string resourceName)
        {
            return Open(resourceName, AccessMode.None, 10 * 1000);
        }

        public IVisaSession Open(string resourceName, AccessMode accessMode, int timeoutMilliseconds)
        {
            ResourceOpenStatus openStatus;
            return Open(resourceName, accessMode, timeoutMilliseconds, out openStatus);
        }

        public IVisaSession Open(string resourceName, AccessMode accessModes, int timeoutMilliseconds, out ResourceOpenStatus openStatus)
        {
            IVisaSession sesn = GlobalResourceManager.Open(resourceName, accessModes, timeoutMilliseconds, out openStatus);
            return sesn;
        }

        public ParseResult Parse(string resourceName)
        {
            throw new NotImplementedException();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: マネージド状態を破棄します (マネージド オブジェクト)
                }

                // TODO: アンマネージド リソース (アンマネージド オブジェクト) を解放し、ファイナライザーをオーバーライドします
                // TODO: 大きなフィールドを null に設定します
                disposedValue = true;
            }
        }

 
        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}