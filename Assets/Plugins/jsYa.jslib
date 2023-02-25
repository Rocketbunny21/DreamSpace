mergeInto(LibraryManager.library, {

  Hello: function () {
    window.alert("Hello, world!");
  },

  HelloString: function (str) {
    window.alert(UTF8ToString(str));
  },

  PrintFloatArray: function (array, size) {
    for(var i = 0; i < size; i++)
    console.log(HEAPF32[(array >> 2) + i]);
  },

  AddNumbers: function (x, y) {
    return x + y;
  },

  StringReturnValueFunction: function () {
    var returnStr = "bla";
    var bufferSize = lengthBytesUTF8(returnStr) + 1;
    var buffer = _malloc(bufferSize);
    stringToUTF8(returnStr, buffer, bufferSize);
    return buffer;
  },

  BindWebGLTexture: function (texture) {
    GLctx.bindTexture(GLctx.TEXTURE_2D, GL.textures[texture]);
  },

	GetLang: function(){
		var lang = ysdk.environment.i18n.lang;
		var bufferSize = lengthBytesUTF8(lang) +1;
		var buffer = _malloc(bufferSize);
		stringToUTF8(lang, buffer, bufferSize);
		return buffer;
	},
	
	ShowAdv: function(){
	
	ysdk.adv.showFullscreenAdv({
	callbacks: {
		onOpen: function(wasOpen){
		myGameInstance.SendMessage("Yandex", "Pause");
		console.log("------------pause--------");
		},
		onClose: function(wasShown){
		myGameInstance.SendMessage("Yandex", "UnPause");
		console.log("ADV");
	},
		onError: function(error){
		}
		}
	})},
	
	Optim: function(){
	if (/iPhone|iPad|iPod|Android/i.test(navigator.userAgent)) 
	{
        var returnStr = "M";
		var bufferSize = lengthBytesUTF8(returnStr) + 1;
		var buffer = _malloc(bufferSize);
		stringToUTF8(returnStr, buffer, bufferSize);
		console.log(buffer);
		return buffer;
      } else {
        var returnStr = "PC";
		var bufferSize = lengthBytesUTF8(returnStr) + 1;
		var buffer = _malloc(bufferSize);
		stringToUTF8(returnStr, buffer, bufferSize);
		console.log(buffer);
		return buffer;
      }
	},
	
	
	
	SetLeaderBoard: function(score){
	var lba;
		
	ysdk.getLeaderboards()
		.then(_lb => lba = _lb);
		
		
		
	ysdk.getLeaderboards()
			.then((lb) => lb.getLeaderboardPlayerEntry('leaderboard'))
			.then((res) => {
				const highScore = res.score;
				console.log(highScore + " resscore");
				return highScore;
			})
			.then((highScore) => {
				console.log(highScore + " high");
				console.log(score + " high");
				score > highScore && lba.setLeaderboardScore('leaderboard', score);
				console.log("high");
			})
  
			.catch((err) => {
				if (err.code === 'LEADERBOARD_PLAYER_NOT_PRESENT') {
					lba.setLeaderboardScore('leaderboard', score);
				}
			});
	},
	
	GetLeaderBoard: function(){
		ysdk.getLeaderboards()
			.then(lb => lb.getLeaderboardPlayerEntry('leaderboard'))
			.then(res => {
			highScore = res.score;
			console.log(highScore);
		})
		.catch(err => {
			if (err.code === 'LEADERBOARD_PLAYER_NOT_PRESENT') {
			// Срабатывает, если у игрока нет записи в лидерборде
			}	
		});
	},
	AuthProv: function(){
	authFalse();
	},
	AuthExtern: function(){
	auth();
	},
	
	SaveData: function(score){
	player.setStats({
		stats: score,
	});
	console.log(score + 'saved');
	},
	
	LoadData: async function(){
		const req = await player.getStats(['stats'])
		const scoreData = req.stats;
		myGameInstance.SendMessage("CreaperArea", "UpdateScoreData", scoreData);
		console.log('dataSend' + req.stats);
		console.log(scoreData);
	}
	
});