// Copyright (c) MOSA Project. Licensed under the New BSD License.

using Mosa.Compiler.Framework.IR;

namespace Mosa.Compiler.Framework.Stages
{
	/// <summary>
	/// Platform Intrinsic Stage
	/// </summary>
	/// <seealso cref="Mosa.Compiler.Framework.BaseMethodCompilerStage" />
	public sealed class PlatformIntrinsicStage : BaseMethodCompilerStage
	{
		protected override void Run()
		{
			foreach (var block in BasicBlocks)
			{
				for (var node = block.AfterFirst; !node.IsBlockEndInstruction; node = node.Next)
				{
					if (node.IsEmptyOrNop)
						continue;

					if (node.Instruction != IRInstruction.IntrinsicMethodCall)
						continue;

					var methodName = node.InvokeMethod.DeclaringType.FullName + ":" + node.InvokeMethod.Name;

					var intrinsic = Architecture.GetInstrinsicMethod(node.InvokeMethod.ExternMethodModule);

					if (intrinsic == null)
						return;

					var operands = node.GetOperands();
					operands.RemoveAt(0);
					node.SetInstruction(IRInstruction.IntrinsicMethodCall, node.Result, operands);

					intrinsic(new Context(node), MethodCompiler);
				}
			}
		}
	}
}
