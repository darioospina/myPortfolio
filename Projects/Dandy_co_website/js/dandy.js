function showSection(sectionId, clickedElement) {
	document.getElementById("infoSection").style.display = "block";
	var clickItems = document.getElementById("optionsMenu").childNodes;
	for (var i = 0; i < clickItems.length; i++) {
		if (clickItems[i].nodeName === "LI") {
			clickItems[i].style.fontWeight = "normal";
		}
	}
	clickedElement.style.fontWeight = "bold";
	var sections = document.getElementsByClassName("hidden");
	for (var i = 0; i < sections.length; i++) {
		sections[i].style.display = "none";
	}
	var sectionToShow = document.getElementById(sectionId);
	sectionToShow.style.display = "block";
}