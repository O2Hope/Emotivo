using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Emotivo.Web.Models;
using Microsoft.ProjectOxford.Common.Contract;
using Microsoft.ProjectOxford.Emotion;
using Emotion = Microsoft.ProjectOxford.Common.Contract.Emotion;

namespace Emotivo.Web.Helpers
{
    public class EmotionHelper
    {
        public EmotionServiceClient Client;

        public EmotionHelper(string key)
        {
            Client = new EmotionServiceClient(key);
        }

        public async Task<Picture> DetectAndExtractAsync(Stream imageStream)
        {
           Emotion[] emotions = await Client.RecognizeAsync(imageStream);

            var picture = new Picture();

            picture.Faces = ExtractFaces(emotions, picture);

            return picture;

        }

        private ObservableCollection<Face> ExtractFaces(Emotion[] emotions, Picture picture)
        {

            var listFaces = new ObservableCollection<Face>();
            
            foreach (var emotion in emotions)
            {
                var face = new Face()
                {
                    X = emotion.FaceRectangle.Left,
                    Y = emotion.FaceRectangle.Top,
                    Width = emotion.FaceRectangle.Width,
                    Height = emotion.FaceRectangle.Height,
                    Picture = picture
                };
                
                face.Emotions = ProccesEmotions(emotion.Scores, face);
                listFaces.Add(face);
            }

            return listFaces;

        }

        private ObservableCollection<Models.Emotion> ProccesEmotions(EmotionScores emotionScores, Face face)
        {
            var emotionList = new ObservableCollection<Models.Emotion>();

            var properties = emotionScores.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var filterProperties = properties.Where(p => p.PropertyType == typeof(float));

            var emotionType = EmotionEnum.Undeterminated;
            
            foreach (var prop in filterProperties)
            {
                if (!Enum.TryParse<EmotionEnum>(prop.Name, out emotionType))
                {
                    emotionType = EmotionEnum.Undeterminated;
                }
                var emotion = new Models.Emotion
                {
                    Score = (float) prop.GetValue(emotionScores),
                    EmotionType = emotionType,
                    Face = face
                };
                
                emotionList.Add(emotion);
                
            }

            return emotionList;
        }
    }
}