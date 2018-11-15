// Copyright (c) MOSA Project. Licensed under the New BSD License.

// This code was generated by an automated template.

using Mosa.Compiler.Framework;

namespace Mosa.Platform.ARMv6.Instructions
{
	/// <summary>
	/// Wfe32 - Wait for Event
	/// </summary>
	/// <seealso cref="Mosa.Platform.ARMv6.ARMv6Instruction" />
	public sealed class Wfe32 : ARMv6Instruction
	{
		public override int ID { get { return 757; } }

		internal Wfe32()
			: base(1, 3)
		{
		}
	}
}
