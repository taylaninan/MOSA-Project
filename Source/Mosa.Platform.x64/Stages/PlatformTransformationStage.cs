// Copyright (c) MOSA Project. Licensed under the New BSD License.

using Mosa.Platform.x64.Transforms.FixedRegisters;
using Mosa.Platform.x64.Transforms.Stack;
using Mosa.Platform.x64.Transforms.Tweak;

namespace Mosa.Platform.x64.Stages;

/// <summary>
/// Platform Transformation Stage
/// </summary>
/// <seealso cref="Mosa.Compiler.Framework.Stages.BaseTransformStage" />
public sealed class PlatformTransformationStage : Compiler.Framework.Stages.BaseTransformStage
{
	public override string Name => "x64." + GetType().Name;

	public PlatformTransformationStage()
		: base(true, false, 0)
	{
		AddTranforms(TweakTransforms.List);
		AddTranforms(FixedRegistersTransforms.List);
		AddTranforms(StackTransforms.List);
		AddTranforms(SpecialTransforms.List);
	}
}
