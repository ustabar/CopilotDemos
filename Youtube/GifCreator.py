from pytube import YouTube
from moviepy.editor import VideoFileClip

def download_video(url):
    youtube = YouTube(url)
    video = youtube.streams.first()
    video.download(filename="c:/analiz/gif/test.mp4")

def convert_to_gif():
    clip = VideoFileClip("c:/analiz/gif/test.mp4")
    clip = clip.subclip(0, 5)  # İlk 5 saniye
    clip.write_gif("c:/analiz/gif/output.gif")

# YouTube video URL'sini buraya girin
url = "https://www.youtube.com/watch?v=dQw4w9WgXcQ"
download_video(url)
convert_to_gif()