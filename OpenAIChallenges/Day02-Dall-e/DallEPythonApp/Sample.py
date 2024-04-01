# Note: DALL-E 3 requires version 1.0.0 of the openai-python library or later
import os
from openai import AzureOpenAI
import json

client = AzureOpenAI(
    api_version="2024-02-01",
    azure_endpoint="https://barutaidemo.openai.azure.com/",
    api_key="c5c31b1c1aaa4919ba701fbcec03f2f8"
)

result = client.images.generate(
    model="dalledemo", # the name of your DALL-E 3 deployment
    prompt="aliens in Punjabi attire",
    n=1
)

image_url = json.loads(result.model_dump_json())['data'][0]['url']
print(image_url)