from pytube import YouTube
from moviepy.editor import VideoFileClip

def download_video(url):
    youtube = YouTube(url)
    video = youtube.streams.first()
    video.download(filename="c:/analiz/gif/test.mp4")

def convert_to_gif():
    clip = VideoFileClip("c:/analiz/gif/test.mp4")
    clip = clip.subclip(43, 51)  # aradan 8 saniye
    clip.write_gif("c:/analiz/gif/output.gif", fps=20, scale=320)

# YouTube video URL'sini buraya girin
url = "https://www.youtube.com/watch?v=XxbJw8PrIkc"
download_video(url)
convert_to_gif()