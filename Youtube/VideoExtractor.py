# https://twitter.com/python_dv/status/1771859253566853242?s=48&t=GXbJCd0xkHq6z5EUZouerw

#pip install pytube
from pytube import YouTube

video_url = 'https://www.youtube.com/watch?v=XxbJw8PrIkc'
save_path = 'C:/Analiz'

# Create a YouTube object
video = YouTube(video_url)

# quality(quality) and format, etc
stream = video.streams.get_highest_resolution()

# Download the video
stream.download(output_path=save_path)

print("Video Downloaded Successfully.")