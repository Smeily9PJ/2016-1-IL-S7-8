using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI2016.Dev
{
    public enum KrabouilleMode
    {
        Krabouille,
        UnKrabouille
    }

    public class KrabouilleStream : Stream
    {
        readonly KrabouilleMode _mode;
        readonly Stream _inner;
        readonly byte[] _secret;

        public KrabouilleStream( Stream inner, KrabouilleMode mode, string secret )
        {
            if (inner == null) throw new ArgumentNullException(nameof(inner));
            if (string.IsNullOrEmpty(secret)) throw new ArgumentException("Must not be null or empty", nameof(secret));
            if(mode == KrabouilleMode.Krabouille)
            {
                if (!inner.CanWrite) throw new ArgumentException("Stream must be writable in krabouille mode.");
            }
            else if (!inner.CanRead)
            {
                throw new ArgumentException("Stream must be readable in unkrabouille mode.");
            }
            _inner = inner;
            _mode = mode;
            _secret = Encoding.UTF7.GetBytes(secret);
        }

        public override bool CanRead => _mode == KrabouilleMode.UnKrabouille;

        public override bool CanSeek => false;

        public override bool CanWrite => _mode == KrabouilleMode.Krabouille;

        public override long Length
        {
            get
            {
                throw new NotSupportedException();
            }
        }

        public override long Position
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public override void Flush()
        {
        }

        public override int Read( byte[] buffer, int offset, int count )
        {
            throw new NotImplementedException();
        }

        public override long Seek( long offset, SeekOrigin origin )
        {
            throw new NotImplementedException();
        }

        public override void SetLength( long value )
        {
            throw new NotImplementedException();
        }

        public override void Write( byte[] buffer, int offset, int count )
        {
            if (!CanWrite) throw new NotSupportedException();

            for (int i = 0; i < count; i++)
            {
              
            }
        }
    }
}
