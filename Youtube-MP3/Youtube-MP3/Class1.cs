using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeExplode;

namespace Youtube_MP3
{
	class Downloader
	{
		private List<YoutubeExplode.Videos.Video> VideoList = new List<YoutubeExplode.Videos.Video>();
		private YoutubeClient youtube = new YoutubeClient();

		public Downloader()
		{
			
		}
		public void AddList(string link) 
		{
			YoutubeExplode.Videos.Video video;
			try
			{
				video = youtube.Videos.GetAsync(link);
				
			}
			catch
			{
				throw new Exception("Il video non è raggiungibile");
				return;
			}

			VideoList.Add(video);
			return;
		}
		public void Remover(int index)
		{
			try
			{
				VideoList.RemoveAt(index);
			}
			catch
			{
				throw new Exception();
			}
		}
		public void DownloadAll() 
		{
			string Manifest;
			foreach(var i in VideoList) 
			{
				var streamManifest = youtube.Videos.Streams.GetManifestAsync(Manifest=i.));
				var stream = youtube.Videos.Streams.DownloadAsync(streamManifest.GetAudioOnlyStreams().GetWithHighestBitrate(), $"video.{streamManifest.GetAudioOnlyStreams().GetWithHighestBitrate().Container}");
			}
		}
	}
}
