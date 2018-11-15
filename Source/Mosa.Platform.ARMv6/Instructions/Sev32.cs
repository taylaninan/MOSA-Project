// Copyright (c) MOSA Project. Licensed under the New BSD License.

// This code was generated by an automated template.

using Mosa.Compiler.Framework;

namespace Mosa.Platform.ARMv6.Instructions
{
	/// <summary>
	/// Sev32 - Send Event
	/// </summary>
	/// <seealso cref="Mosa.Platform.ARMv6.ARMv6Instruction" />
	public sealed class Sev32 : ARMv6Instruction
	{
		public override int ID { get { return 741; } }

		internal Sev32()
			: base(1, 3)
		{
		}
	}
}
