# Here's a simple Python script that uses regular expressions to detect and remove potential 
# Personally Identifiable Information (PII) from a text string. This script checks for email addresses, 
# phone numbers, and credit card numbers, which are common types of PII.

import re

def remove_pii(text):
    # Email addresses
    text = re.sub(r'\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Z|a-z]{2,}\b', '[REDACTED]', text)

    # Phone numbers
    text = re.sub(r'\b(\+\d{1,2}\s?)?1?\-?\.?\s?\(?\d{3}\)?[\s.-]?\d{3}[\s.-]?\d{4}\b', '[REDACTED]', text)

    # Credit card numbers
    text = re.sub(r'\b\d{4}[\s-]?\d{4}[\s-]?\d{4}[\s-]?\d{4}\b', '[REDACTED]', text)

    return text

text = "My email is john.doe@example.com and my phone number is 123-456-7890. My credit card number is 1234-5678-9012-3456."
print(remove_pii(text))