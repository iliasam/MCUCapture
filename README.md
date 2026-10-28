# MCUCapture

This Windows utility plots array data from MCU RAM. Instead of utilities like "STM Studio", this utility is working with a single RAM array. 
It can be useful for displaying data captured by ADC, and so on. Supported saving captured array data to file.  
Also, this utility can be used for capturing B/W screenshots from the MCU framebuffer.  

  
Utility screenshot:
![Alt text](Screenshots/picture1.png?raw=true "Image")  

This utility is using the OpenOCD connection to the MCU. Connection to the OpenOCD is made by Telnet at port 4444.  
I made a special patched version of OpenOCD to get value watchpoint support for Cortex-M. This is needed for "Capture Trigger" functionality. You can download it here: https://yadi.sk/d/tDvl2aGxWSdeHg    

Example of starting OpenOCD for STM32F4: "openocd -d2 -f interface/stlink.cfg -f target/stm32f4x.cfg"  

## Utility usage:  

#### Getting plot data:  

1. Enter the array address and its length in the "Start address" and "Array size, bytes" fields.

2. Press the "Manual Read" button to capture data from MCU. There is no auto-halt function, and the readout is slow, so there is no synchronization during data readout.  

Pressing the "Wait End WP" button will set the write watchpoint to the last byte of the array. When the watchpoint event happens, 
the MCU will enter halt mode, and the utility will automatically read data from RAM. After completion of that process, the watchpoint will be removed.  

This mode is not working when data is written to the RAM by DMA.  
Pressing the "Wait Trigger" button will set the value watchpoint to the address entered in the "Variable address" field. This mode is similar to the previous mode, 
but a certain variable can be used as a "trigger".
You can set a data structure by the "Data Structure" group. It is useful when data is captured by ADC from several channels.  
Array and trigger value addresses can be taken from .elf, .out, *.afx files:  

![Alt text](Screenshots/picture3.png?raw=true "Image")  
Select the "Data Saving" tab for saving captured data to file. Data capture is started as previously described.  

#### Capturing framebuffer:  
Now this is supported for B/W displays like OLED with SDD1306 or LCD with ST7565R (a single byte contains 8 vertical pixels; data is organized horizontally).  
![Alt text](Screenshots/picture2.png?raw=true "Image")  
You can get the cursor position by pressing on the image.

#### Fast OpenOCD start:  
Added in 2026.  
OpenOCD can be started quickly with a special window, which can be opened by pressing to the "OpenOCD" button at the main window.
It is looking so:  
![Alt text](Screenshots/picture4.png?raw=true "Image")  
You can add here different paths to your OpenOCD versions,  and add a different variants of a configuration keys. 
