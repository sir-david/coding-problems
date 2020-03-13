let normalizeString = (inputString) => inputString.normalize('NFD').replace(/[\u0300-\u036f]/g, ""),
	getASCIIArray = (inputString) => {
		let res = [];
		for (let i = 0; i < inputString.length; i++)
			res.push(inputString[i].charCodeAt(0));
		return res;
	}, 
	matchWord =  (source, textToFind, caseSensitiveEnabled=false, normalizeStringEnabled=true)=>{				
		let sourceText = caseSensitiveEnabled ? source : source.toLowerCase(),
			textToSearch = caseSensitiveEnabled ? textToFind : textToFind.toLowerCase();
		sourceText = normalizeStringEnabled ? normalizeString(sourceText) : sourceText
		textToSearch = normalizeStringEnabled ? normalizeString(textToSearch) : textToSearch; 
		let vectorForSearch = getASCIIArray(sourceText),
			vectorToFind = getASCIIArray(textToSearch),
			res = [];

		for (let i = 0; i < vectorForSearch.length; i++) {
			if (vectorForSearch[i] === vectorToFind[0]) {
				let suspectedInitialPoint = i;
				let wasFullMatch = true;
				for (let j = 1; j < vectorToFind.length; j++) {
					i++;
					if (vectorToFind[j] !== vectorForSearch[i] || i >= vectorForSearch.length) {
						wasFullMatch = false;
						break;
					}
				}
				if (wasFullMatch)
					res.push(suspectedInitialPoint+1);
				else
					i--;
			}
		}
		return res.length > 0 ? res : undefined;
	};

///
///	Parametro 1: * source: Texto en el que se va a buscar
///	Parametro 2: * textToFind: Frase a buscar 
///	Parametro 3: * caseSensitiveEnabled: Por defecto esta deshabilitado. Validar mayusculas y minusculas
///	Parametro 4: * normalizeStringEnabled: Por defecto esta habilitado. Quitar tildes basados en NFD (Forma de Normalización de Composición Canónica.)
///
(matchWord("Polly put the kettle on, polly put the kettle on, polly put the kettle on we'll all have tea", "Polly")  || ["<no matches>"]).join(", ");
(matchWord("Polly put the kettle on, polly put the kettle on, polly put the kettle on we'll all have tea", "polly")  || ["<no matches>"]).join(", ");
(matchWord("Polly put the kettle on, polly put the kettle on, polly put the kettle on we'll all have tea", "ll")  || ["<no matches>"]).join(", ");
(matchWord("Polly put the kettle on, polly put the kettle on, polly put the kettle on we'll all have tea", "Ll")  || ["<no matches>"]).join(", ");
(matchWord("Polly put the kettle on, polly put the kettle on, polly put the kettle on we'll all have tea", "X")  || ["<no matches>"]).join(", ");
(matchWord("Polly put the kettle on, polly put the kettle on, polly put the kettle on we'll all have tea", "Polx")  || ["<no matches>"]).join(", ");





