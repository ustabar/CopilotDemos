from pynput.mouse import Listener as MouseListener
from pynput.keyboard import Listener as KeyboardListener
from pynput.keyboard import Key

def on_move(x, y):
    print(f'Mouse moved to ({x}, {y})')

def on_click(x, y, button, pressed):
    print(f'Mouse {"pressed" if pressed else "released"} at ({x}, {y})')

def on_scroll(x, y, dx, dy):
    print(f'Mouse scrolled at ({x}, {y})')

def on_press(key):
    print(f'Key {key} pressed')
    if key == Key.esc:  # Stop listener if esc is pressed
        return False

def on_release(key):
    print(f'Key {key} released')

# Start the mouse listener
mouse_listener = MouseListener(on_move=on_move, on_click=on_click, on_scroll=on_scroll)
mouse_listener.start()

# Start the keyboard listener
keyboard_listener = KeyboardListener(on_press=on_press, on_release=on_release)
keyboard_listener.start()

# Keep the script running
mouse_listener.join()
keyboard_listener.join()