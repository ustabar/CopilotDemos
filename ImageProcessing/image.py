from PIL import Image
import requests
from io import BytesIO

## from urllib.request import urlopen

# Download the image
response = requests.get("https://source.unsplash.com/random")
img = Image.open(BytesIO(response.content))

## response = urlopen("https://source.unsplash.com/random")
## img = Image.open(BytesIO(response.read()))

# Save the original image
img.save("original.png")

# Create a square version of the image by adding a transparent background
max_size = max(img.size)
square_img = Image.new('RGBA', (max_size, max_size), (0, 0, 0, 0))  # Create a new image with transparent background
square_img.paste(img, (int((max_size - img.size[0]) / 2), int((max_size - img.size[1]) / 2)))  # Paste the original image onto the transparent background
square_img.save("square.png")

# Resize the image to 1000x1000
resized_img = img.resize((1000, 1000))
resized_img.save("resized.png")

# Create a 256x256 greyscale version of the image
small_grey_img = img.resize((256, 256)).convert("L")
small_grey_img.save("small_grey.png")
