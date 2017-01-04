﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Booma.Entity.Identity
{
	/// <summary>
	/// Simple container for building GUIDs.
	/// </summary>
	public class NetworkEntityGuidBuilder
	{
		/// <summary>
		/// The raw 64bit guid value.
		/// </summary>
		public ulong RawGuid { get; set; }

		/// <summary>
		/// Sets the <see cref="NetworkEntityGuid.EntityId"/> to the provided <paramref name="id"/>.
		/// </summary>
		/// <param name="id">The ID for the entity.</param>
		/// <returns></returns>
		public NetworkEntityGuidBuilder WithId(int id)
		{
			RawGuid &= 0xFFFFFFFF00000000; //remove current ID

			RawGuid |= ((ulong)(Int64)id); //bitwise or the ID into the raw guid value.

			return this;
		}

		public NetworkEntityGuidBuilder WithType(EntityType type)
		{
			RawGuid &= 0xFF00FFFFFFFFFFFF; //remove current entity type.

			RawGuid |= (ulong)(Int64)(((byte)type) << 48);

			return this;
		}

		/// <summary>
		/// Generates the <see cref="NetworkEntityGuid"/> object.
		/// </summary>
		/// <returns>A non-null <see cref="NetworkEntityGuid"/> with the <see cref="RawGuid"/>.</returns>
		public NetworkEntityGuid Build()
		{
			return new NetworkEntityGuid(RawGuid);
		}
	}
}
