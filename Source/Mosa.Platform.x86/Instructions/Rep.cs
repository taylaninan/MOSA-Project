// Copyright (c) MOSA Project. Licensed under the New BSD License.

// This code was generated by an automated template.

using Mosa.Compiler.Framework;

namespace Mosa.Platform.x86.Instructions
{
	/// <summary>
	/// Rep
	/// </summary>
	/// <seealso cref="Mosa.Platform.x86.X86Instruction" />
	public sealed partial class Rep : X86Instruction
	{
		private static readonly byte[] opcode = new byte[] { 0xF3 };

		public Rep()
			: base(0, 0)
		{
		}

		public override void Emit(InstructionNode node, BaseCodeEmitter emitter)
		{
			emitter.Write(opcode);
		}

		public override byte[] __opcode { get { return opcode; } }
	}
}

