import re
import os
import base64

def extract_and_replace_images(file_path, output_dir):
    # Read the markdown file
    with open(file_path, 'r') as file:
        data = file.read()

    # Find all base64 encoded PNG images
    images = re.findall(r'!\[\]\((data:image/png;base64,[^\)]+)\)', data)

    for i, img_data in enumerate(images):
        # Extract the base64 string
        base64_str = img_data.split(',')[1]

        # Convert to bytes
        img_bytes = base64.b64decode(base64_str)

        # Create a unique file name
        img_file = os.path.join(output_dir, f'image{i}.png')

        # Write the bytes to a PNG file
        with open(img_file, 'wb') as file:
            file.write(img_bytes)

        # Replace the base64 image with the file path in the markdown file
        data = data.replace(img_data, img_file)

    # Write the updated data back to the markdown file
    with open(file_path, 'w') as file:
        file.write(data)

# Usage
extract_and_replace_images('./Notes.md', './images')