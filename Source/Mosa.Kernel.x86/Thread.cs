﻿// Copyright (c) MOSA Project. Licensed under the New BSD License.

using System.Threading;
using Mosa.Runtime;

namespace Mosa.Kernel.x86;

internal class Thread
{
	public ThreadStatus Status = ThreadStatus.Empty;
	public Pointer StackTop;
	public Pointer StackBottom;
	public Pointer StackStatePointer;
	public uint Ticks;
}
