﻿namespace dot10.DotNet {
	/// <summary>
	/// Public key / public key token base class
	/// </summary>
	public abstract class PublicKeyBase {
		/// <summary>
		/// The key data
		/// </summary>
		protected byte[] data;

		/// <summary>
		/// Returns <c>true</c> if <see cref="Data"/> is <c>null</c> or empty
		/// </summary>
		public bool IsNullOrEmpty {
			get { return data == null || data.Length == 0; }
		}

		/// <summary>
		/// Returns <c>true</c> if <see cref="Data"/> is <c>null</c>
		/// </summary>
		public bool IsNull {
			get { return data == null; }
		}

		/// <summary>
		/// Gets/sets key data
		/// </summary>
		public virtual byte[] Data {
			get { return data; }
			set { data = value; }
		}

		/// <summary>
		/// Default constructor
		/// </summary>
		protected PublicKeyBase() {
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="data">Key data</param>
		protected PublicKeyBase(byte[] data) {
			this.data = data;
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="hexString">Key data as a hex string or the string <c>"null"</c>
		/// to set key data to <c>null</c></param>
		protected PublicKeyBase(string hexString) {
			this.data = Parse(hexString);
		}

		static byte[] Parse(string hexString) {
			if (hexString == null || hexString == "null")
				return null;
			return Utils.ParseBytes(hexString);
		}

		/// <summary>
		/// Returns a <see cref="PublicKeyToken"/>
		/// </summary>
		/// <param name="pkb">A <see cref="PublicKey"/> or a <see cref="PublicKeyToken"/> instance</param>
		public static PublicKeyToken ToPublicKeyToken(PublicKeyBase pkb) {
			var pkt = pkb as PublicKeyToken;
			if (pkt != null)
				return pkt;
			var pk = pkb as PublicKey;
			if (pk != null)
				return pk.Token;
			return null;
		}

		/// <inheritdoc/>
		public override string ToString() {
			if (IsNullOrEmpty)
				return "null";
			return Utils.ToHex(data, false);
		}
	}
}
