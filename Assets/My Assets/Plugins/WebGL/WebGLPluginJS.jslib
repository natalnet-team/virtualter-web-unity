// Creating functions for the Unity
mergeInto(LibraryManager.library, {

   // Metódo usado para enviar pontuação para a página
   SendPointsToPage: function (number){
		// Função que será usada no JS
		ReceivePointsFromUnity(number);
   },

   SendTimeToPage: function (number){
		ReceiveTimeFromUnity(number);
   },

   SendCoinsNumberToPage: function (number){
		ReceiveCoinsNumberFromUnity(number);
   },

   SendLevelToPage: function (number){
		ReceiveLevelFromUnity(number);
   }
});