var OpenWindowPlugin = {
    openWindow: function(link)
    {
    	var url = Pointer_stringify(link);
      window.open(url, "_self");
    }
};

mergeInto(LibraryManager.library, OpenWindowPlugin);