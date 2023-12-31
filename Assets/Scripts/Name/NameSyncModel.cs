using Normal.Realtime;
using Normal.Realtime.Serialization;

namespace Name
{
    [RealtimeModel]
    public partial class NameSyncModel
    {
        [RealtimeProperty(1, true, true)] private string _name;
    }
}

/* ----- Begin Normal Autogenerated Code ----- */
namespace Name {
    public partial class NameSyncModel : RealtimeModel {
        public string name {
            get {
                return _nameProperty.value;
            }
            set {
                if (_nameProperty.value == value) return;
                _nameProperty.value = value;
                InvalidateReliableLength();
                FireNameDidChange(value);
            }
        }
        
        public delegate void PropertyChangedHandler<in T>(NameSyncModel model, T value);
        public event PropertyChangedHandler<string> nameDidChange;
        
        public enum PropertyID : uint {
            Name = 1,
        }
        
        #region Properties
        
        private ReliableProperty<string> _nameProperty;
        
        #endregion
        
        public NameSyncModel() : base(null) {
            _nameProperty = new ReliableProperty<string>(1, _name);
        }
        
        protected override void OnParentReplaced(RealtimeModel previousParent, RealtimeModel currentParent) {
            _nameProperty.UnsubscribeCallback();
        }
        
        private void FireNameDidChange(string value) {
            try {
                nameDidChange?.Invoke(this, value);
            } catch (System.Exception exception) {
                UnityEngine.Debug.LogException(exception);
            }
        }
        
        protected override int WriteLength(StreamContext context) {
            var length = 0;
            length += _nameProperty.WriteLength(context);
            return length;
        }
        
        protected override void Write(WriteStream stream, StreamContext context) {
            var writes = false;
            writes |= _nameProperty.Write(stream, context);
            if (writes) InvalidateContextLength(context);
        }
        
        protected override void Read(ReadStream stream, StreamContext context) {
            var anyPropertiesChanged = false;
            while (stream.ReadNextPropertyID(out uint propertyID)) {
                var changed = false;
                switch (propertyID) {
                    case (uint) PropertyID.Name: {
                        changed = _nameProperty.Read(stream, context);
                        if (changed) FireNameDidChange(name);
                        break;
                    }
                    default: {
                        stream.SkipProperty();
                        break;
                    }
                }
                anyPropertiesChanged |= changed;
            }
            if (anyPropertiesChanged) {
                UpdateBackingFields();
            }
        }
        
        private void UpdateBackingFields() {
            _name = name;
        }
        
    }
}
/* ----- End Normal Autogenerated Code ----- */
