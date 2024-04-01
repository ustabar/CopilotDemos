import mammoth

def convert_docx_to_markdown(file_path):
    with open(file_path, "rb") as docx_file:
        result = mammoth.convert_to_markdown(docx_file)
        markdown = result.value  # The generated markdown text
        messages = result.messages  # Any messages, such as warnings during conversion
    return markdown, messages

def write_to_file(markdown_text, output_file_path):
    with open(output_file_path, "w", encoding='utf-8') as output_file:
        output_file.write(markdown_text)

# Usage
markdown_text, messages = convert_docx_to_markdown("C:/Analiz/Notes.docx")
write_to_file(markdown_text, "C:/Analiz/Notes.md")