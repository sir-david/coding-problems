let normalizeString = (inputString) => inputString.normalize('NFD').replace(/[\u0300-\u036f]/g, ""),
	getASCIIArray = (inputString) => {
		let res = [];
		for (let i = 0; i < inputString.length; i++)
			res.push(inputString[i].charCodeAt(0));
		return res;
	}, 
	matchWord =  (source, textToFind, caseSensitiveEnabled=false, normalizeStringEnabled=true)=>{				
		let sourceText = caseSensitiveEnabled ? source : source.toLowerCase(),
			textToFind = caseSensitiveEnabled ? textToFind : textToFind.toLowerCase();
		sourceText = normalizeStringEnabled ? normalizeString(source) : source
		textToFind = normalizeStringEnabled ? normalizeString(textToFind) : textToFind;
		console.log(sourceText, textToFind);
		let vectorForSearch = getASCIIArray(sourceText),
			vectorToFind = getASCIIArray(textToFind),
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
					res.push(suspectedInitialPoint);
				else
					i--;
			}
		}
		return res;
	};

///
///	Parametro 1: * source: Texto en el que se va a buscar
///	Parametro 2: * textToFind: Frase a buscar 
///	Parametro 3: * caseSensitiveEnabled: Por defecto esta deshabilitado. Validar mayusculas y minusculas
///	Parametro 4: * normalizeStringEnabled: Por defecto esta habilitado. Quitar tildes basados en NFD (Forma de Normalización de Composición Canónica.)
///
matchWord('SExta frase más extensa que comedia francexsa al meXdiodía con tu éx', 'ex').join(', ');  





