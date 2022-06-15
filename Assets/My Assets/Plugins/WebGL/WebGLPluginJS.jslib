// Creating functions for the Unity
mergeInto(LibraryManager.library, {

   // Met�do usado para enviar pontua��o para a p�gina
   SendPointsToPage: function (number){
		// Fun��o que ser� usada no JS
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