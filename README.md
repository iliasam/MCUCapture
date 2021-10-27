# MCUCapture
This Windows utility plot array data from MCU RAM. Instead of utilities like "STM Studio", this utility is working with single RAM array. 
It could be useful for displaying data captured by ADC, and so on. Supported saving captured array data to file.  
Also this utility could be used for capturing B/W screnshots from MCU framebuffer.  
  
Utility screenshot:
![Alt text](Screenshots/picture1.png?raw=true "Image")  
  
This utility is using OpenOCD connection to the MCU. Connection to the OpenOCD is made by Telnet at 4444 port.  
I made a special patched version of OpenOCD to get value watchpoint support for Cortex-M. This is needed for "Capture Trigger" functionality. You can download it here: https://yadi.sk/d/tDvl2aGxWSdeHg    
Example of starting OpenOCD for STM32F4: "openocd -d2 -f interface/stlink.cfg -f target/stm32f4x.cfg"  

## Utility usage:  
#### Getting plot data:  
1. Enter array address and its length to "Start address" and "Array size, bytes" fields.
2. Press "Manual Read" button to capture data from MCU. There is no auto halt function and the readout is slow, so there is no synchronization during data readout.  
Pressing "Wait End WP" button will set write watchpoint to the the last byte of the array. When watchpoint event happens, 
the MCU will enter to halt mode, and utility will automatically read data from RAM. After completion of that process watchpoint will be removed.  
This mode is not working when data is written to the RAM by DMA.  
Pressing "Wait Trigger" button will set value watchpoint to the address entered to "Variable address" field. This mode is similar to previous mode, 
but a certain variable could be used as a "trigger".

You can set data structure by "Data Structure" group. It is useful when data is captured by ADC from several channels.  

Array and trigger value addresses could be taken from *.elf, *.out, *.afx files:  
![Alt text](Screenshots/picture3.png?raw=true "Image")  

Select "Data Saving" tab for saving captured data to file. Data capture is started as previously described.  

#### Capturing framebuffer:  
Now this is supported for B/W displays like OLED with SDD1306 or LCD with ST7565R (single byte contains 8 vertical pixels, data is  organized horizontally).  
![Alt text](Screenshots/picture2.png?raw=true "Image")  
You can get cursor position by pressing to the image.
