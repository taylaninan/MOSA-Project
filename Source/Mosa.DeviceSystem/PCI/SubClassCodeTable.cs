// Copyright (c) MOSA Project. Licensed under the New BSD License.

namespace Mosa.DeviceSystem.PCI;

/// <summary>
///
/// </summary>
public static class SubClassCodeTable
{
	/// <summary>
	/// Looks up the specified sub class code.
	/// </summary>
	/// <param name="classCode">The class code.</param>
	/// <param name="subClassCode">The sub class code.</param>
	/// <param name="progIF">The prog IF.</param>
	/// <returns></returns>
	public static string Lookup(byte classCode, byte subClassCode, byte progIF)
	{
		return ((classCode << 16) | (subClassCode << 8) | progIF) switch
		{
			0x000000 => "Non-VGA Device",
			0x000001 => "VGA Device",
			0x010000 => "SCSI Controller",
			0x010100 => "IDE controller",
			0x010101 => "IDE controller",
			0x010102 => "IDE controller",
			0x010103 => "IDE controller",
			0x010104 => "IDE controller [reserved]",
			0x010105 => "IDE controller [reserved]",
			0x010106 => "IDE controller [reserved]",
			0x010107 => "IDE controller [Master IDE Device]",
			0x010200 => "Floppy Disk",
			0x010300 => "IPI controller",
			0x010400 => "RAID controller",
			0x010520 => "ATA controller [Single DMA]",
			0x010530 => "ATA controller [Chained DMA]",
			0x010600 => "Serial ATA controller",
			0x010601 => "Serial ATA controller [ACHI]",
			0x010700 => "Serial Attached SCSI (SAS) controller",
			0x018000 => "Mass storage controller",
			0x020000 => "Ethernet controller",
			0x020100 => "Token ring",
			0x020200 => "FDDI controller",
			0x020300 => "ATM controller",
			0x020500 => "WorldFlip controller",
			0x020600 => "PCIMG 2.14 controller" // Prog. I/F xxh per spec
			,
			0x028000 => "Network controller",
			0x030000 => "VGA compatable controller",
			0x030001 => "8514 compatable",
			0x030100 => "XGA controller",
			0x030200 => "3D controller",
			0x038080 => "Display controller",
			0x040000 => "Video device",
			0x040100 => "Audio device",
			0x040200 => "Computer telephony device",
			0x048000 => "Multimedia device",
			0x050000 => "RAM controller",
			0x050100 => "Flash memory controller",
			0x058000 => "Memory controller",
			0x060000 => "Host/PCI bridge",
			0x060100 => "ISA bridge",
			0x060200 => "EISA bridge",
			0x060300 => "Micro Channel bridge",
			0x060400 => "PCI-to-PCI bridge",
			0x060401 => "Subtractive PCI-to-PCI bridge",
			0x060500 => "PCMCIA bridge",
			0x060600 => "NuBus bridge",
			0x060700 => "CardBus bridge",
			0x060800 => "RACEWay bridge" // Prog. I/F xxh per spec
			,
			0x060940 => "Semi-transparent PCI-to-PCI bridge [Primary]",
			0x060980 => "Semi-transparent PCI-to-PCI bridge [Secondary]",
			0x060A00 => "InfiniBand bridge",
			0x068000 => "Bridge device",
			0x070001 => "Generic XT compatable serial controller",
			0x070002 => "16450-compatable serial controller",
			0x070003 => "16550-compatable serial controller",
			0x070004 => "16750-compatable serial controller",
			0x070005 => "16850-compatable serial controller",
			0x070006 => "16950-compatable serial controller",
			0x070100 => "Parallel port",
			0x070101 => "Bi-directional parallel port",
			0x070102 => "ECP 1.X parallel port",
			0x070103 => "IEEE1284 controller",
			0x0701FE => "IEEE1284 target device",
			0x070200 => "Multiport serial controller",
			0x070300 => "Generic modem",
			0x070301 => "Hayes compatible modem [16450]",
			0x070302 => "Hayes compatible modem [16550]",
			0x070303 => "Hayes compatible modem [16650]",
			0x070304 => "Hayes compatible modem [16750]",
			0x070400 => "GPIB device",
			0x070500 => "Smart Card",
			0x078000 => "Communications device",
			0x080000 => "Generic 8259 programmable interrupt controller (PIC)",
			0x080001 => "ISA PIC",
			0x080002 => "EISA PIC",
			0x080010 => "I/O APIC interrupt controller",
			0x080020 => "I/O APIC interrupt controller",
			0x080100 => "Generic 8237 DMA controller",
			0x080101 => "ISA DMA controller",
			0x080102 => "EISA DMA controller",
			0x080200 => "Generic 8254 timer",
			0x080201 => "ISA system timer",
			0x080202 => "EISA system timer",
			0x080300 => "Generic RTC controller",
			0x080301 => "ISA RTC controller",
			0x080400 => "Generic PCI Hot-Plug controller",
			0x080500 => "SD Host controller",
			0x088000 => "System peripheral",
			0x090000 => "Keyboard controller",
			0x090100 => "Digitizer (pen)",
			0x090200 => "Mouse controller",
			0x090300 => "Scanner controller",
			0x090400 => "Gameport controller",
			0x090410 => "Gameport controller",
			0x098000 => "Input controller",
			0x0A0000 => "Generic docking station",
			0x0A8000 => "Docking station",
			0x0B0000 => "386",
			0x0B0100 => "486",
			0x0B0200 => "Pentium",
			0x0B1000 => "Alpha",
			0x0B2000 => "PowerPC",
			0x0B4000 => "Co-Processor",
			0x0C0000 => "IEEE 1394 (FireWire)",
			0x0C0110 => "IEEE 1394 (FireWire) [OpenHCI]",
			0x0C0100 => "ACCESS bus",
			0x0C0200 => "SSA (Serial Storage Architecture)",
			0x0C0300 => "USB (Universal Serial Bus)",
			0x0C0310 => "USB (Universal Serial Bus)",
			0x0C0320 => "USB (Universal Serial Bus)",
			0x0C0380 => "USB (Universal Serial Bus)",
			0x0C03FE => "USB (Universal Serial Bus)",
			0x0C0400 => "Fibre Channel",
			0x0C0500 => "SMBus (System Management Bus)",
			0x0C0600 => "InfiniBand",
			0x0C0700 => "IPMI SMIC interface",
			0x0C0701 => "IPMI Kybd controller interface",
			0x0C0702 => "IPMI Block Transfer interface",
			0x0C0800 => "SERCOS interface (IEC 61491)",
			0x0C0900 => "CANbus",
			0x0D0000 => "iRDA compatible controller",
			0x0D0100 => "Consumer IR controller",
			0x0D1000 => "RF controller",
			0x0D1100 => "Bluetooth",
			0x0D1200 => "Broadband",
			0x0D2000 => "Ethernet (802.11a - 5 GHz)",
			0x0D2100 => "Ethernet (802.11b - 2.4 GHz)",
			0x0D8000 => "Wireless controller",
			0x0E0000 => "Intelligent I/O (I2O)",
			0x0F0100 => "TV",
			0x0F0200 => "Audio",
			0x0F0300 => "Voice",
			0x0F0400 => "Data",
			0x100000 => "Network and computing encryption",
			0x101000 => "Entertainment encryption",
			0x108000 => "Other encryption",
			0x110000 => "DPIO modules",
			0x110100 => "Performance counters",
			0x111000 => "Communications synchronization",
			0x112000 => "Management card",
			0x118000 => "Data acquisition/signal processing controllers",
			_ => string.Empty
		};
	}
}
