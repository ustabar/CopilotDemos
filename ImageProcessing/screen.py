import cv2
import numpy as np
import pyautogui
import pygetwindow as gw
from mss import mss
from screeninfo import get_monitors

# Capture the screen
sct = mss()
screenshot = sct.grab(sct.monitors[1])
screenshot = cv2.cvtColor(np.array(screenshot), cv2.COLOR_RGBA2RGB)

# Save the screenshot
cv2.imwrite('C:\Codes\CoPilotApp\Problems\ImageProcessing\screenshot-1.png', screenshot)

screenshot = sct.grab(sct.monitors[2])
screenshot = cv2.cvtColor(np.array(screenshot), cv2.COLOR_RGBA2RGB)

# Save the screenshot
cv2.imwrite('C:\Codes\CoPilotApp\Problems\ImageProcessing\screenshot-2.png', screenshot)

# Get a list of all open window titles
window_titles = gw.getAllTitles()

# Print the list
for title in window_titles:
    if title:  # Skip windows with no title
        print(title)

# # Get the window of the specific application
app_window = gw.getWindowsWithTitle('Program Manager')[0]

# # Get the position of the window
x, y, width, height = app_window.left, app_window.top, app_window.width, app_window.height

# Get the list of monitors
monitors = get_monitors()

# Check which monitor the window is in
for i, monitor in enumerate(monitors, start=1):
    if x >= monitor.x and y >= monitor.y and x < monitor.x + monitor.width and y < monitor.y + monitor.height:
        print(f'The window is in monitor {i}')
        # Capture the screen of the specific application
        screenshot = pyautogui.screenshot(region=(x, y, width, height))
        screenshot = cv2.cvtColor(np.array(screenshot), cv2.COLOR_RGB2BGR)
        # Save the screenshot
        cv2.imwrite(f'C:\Codes\CoPilotApp\Problems\ImageProcessing\screenshot_monitor_{i}.png', screenshot)
        break
