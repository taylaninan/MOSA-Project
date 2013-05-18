/*
 * (c) 2013 MOSA - The Managed Operating System Alliance
 *
 * Licensed under the terms of the New BSD License.
 *
 * Authors:
 *  Phil Garcia (tgiphil) <phil@thinkedge.com>
 */

using Mosa.Compiler.Framework;
using Mosa.Compiler.Framework.IR;
using Mosa.Compiler.Metadata.Signatures;
using System.Diagnostics;

namespace Mosa.Platform.x86.Stages
{
	/// <summary>
	/// Completes the stack handling after register allocation
	/// </summary>
	public sealed class BuildStackStage : BaseMethodCompilerStage, IMethodCompilerStage, IPipelineStage
	{
		#region IMethodCompilerStage

		/// <summary>
		/// Setup stage specific processing on the compiler context.
		/// </summary>
		void IMethodCompilerStage.Run()
		{
			if (methodCompiler.Compiler.PlugSystem.GetPlugMethod(methodCompiler.Method) != null)
				return;

			Debug.Assert((methodCompiler.StackLayout.StackSize % 4) == 0, @"Stack size of method can't be divided by 4!!");

			UpdatePrologue();
			UpdateEpilogue();
		}

		#endregion IMethodCompilerStage

		/// <summary>
		/// Updates the prologue.
		/// </summary>
		private void UpdatePrologue()
		{
			// Update prologue Block
			var prologueBlock = this.basicBlocks.PrologueBlock;

			if (prologueBlock != null)
			{
				Context prologueContext = new Context(instructionSet, prologueBlock);

				prologueContext.GotoNext();

				Debug.Assert(prologueContext.Instruction is Prologue);

				AddPrologueInstructions(prologueContext);
			}
		}

		/// <summary>
		/// Updates the epilogue.
		/// </summary>
		private void UpdateEpilogue()
		{
			// Update epilogue Block
			var epilogueBlock = this.basicBlocks.EpilogueBlock;

			if (epilogueBlock != null)
			{
				Context epilogueContext = new Context(instructionSet, epilogueBlock);

				epilogueContext.GotoNext();

				Debug.Assert(epilogueContext.Instruction is Epilogue);

				AddEpilogueInstructions(epilogueContext);
			}
		}

		/// <summary>
		/// Adds the prologue instructions.
		/// </summary>
		/// <param name="context">The context.</param>
		private void AddPrologueInstructions(Context context)
		{
			Operand ebp = Operand.CreateCPURegister(BuiltInSigType.Int32, GeneralPurposeRegister.EBP);
			Operand esp = Operand.CreateCPURegister(BuiltInSigType.Int32, GeneralPurposeRegister.ESP);

			bool breakFlag = false; // TODO: Turn this into a compiler option

			/*
			 * If you want to stop at the header of an emitted function, just set breakFlag
			 * to true in the following line. It will issue a breakpoint instruction. Note
			 * that if you debug using visual studio you must enable unmanaged code
			 * debugging, otherwise the function will never return and the breakpoint will
			 * never appear.
			 */

			// push ebp
			context.SetInstruction(X86.Push, null, ebp);

			// mov ebp, esp
			context.AppendInstruction(X86.Mov, ebp, esp);

			// sub esp, localsSize
			context.AppendInstruction(X86.Sub, esp, esp, Operand.CreateConstant(-methodCompiler.StackLayout.StackSize));

			if (breakFlag)
			{
				// int 3
				context.AppendInstruction(X86.Break);

				// Uncomment this line to enable breakpoints within Bochs
				//context.AppendInstruction(CPUx86.Instruction.BochsDebug);
			}
		}

		/// <summary>
		/// Adds the epilogue instructions.
		/// </summary>
		/// <param name="context">The context.</param>
		private void AddEpilogueInstructions(Context context)
		{
			Operand ebp = Operand.CreateCPURegister(BuiltInSigType.Int32, GeneralPurposeRegister.EBP);
			Operand esp = Operand.CreateCPURegister(BuiltInSigType.Int32, GeneralPurposeRegister.ESP);

			// add esp, -localsSize
			context.SetInstruction(X86.Add, esp, esp, Operand.CreateConstant(BuiltInSigType.IntPtr, -methodCompiler.StackLayout.StackSize));

			// pop ebp
			context.AppendInstruction(X86.Pop, ebp);

			// ret
			context.AppendInstruction(X86.Ret);
		}
	}
}