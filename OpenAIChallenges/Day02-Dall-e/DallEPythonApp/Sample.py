# Note: DALL-E 3 requires version 1.0.0 of the openai-python library or later
import os
from openai import AzureOpenAI
import json

client = AzureOpenAI(
    api_version="2024-02-01",
    azure_endpoint="https://***.openai.azure.com/",
    api_key="****"
)

result = client.images.generate(
    model="dalledemo", # the name of your DALL-E 3 deployment
    prompt="aliens in Punjabi attire",
    n=1
)

image_url = json.loads(result.model_dump_json())['data'][0]['url']
print(image_url)
