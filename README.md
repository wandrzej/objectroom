# Object Room
quick and dirty reproduction of the Objects Room dataset from Deep Mind https://github.com/deepmind/multi_object_datasets#objects-room

All of the settings like number of spawned objects, types of objects, spawn area etc. are set through the Simulation Manager object in the scene. 
At the moment Unity Perception SDK doesn't directly render depth maps, so as a workaround this is done through the Recorder. 

To get RGB + segmentation masks + instance masks - just hit play and all the files will be saves in the c:\Users\XXXX\AppData\LocalLow\ObjectRoom\ObjectRoom\XXXXXX folder

To get RGB + depth + segmentation masks + instance masks - the game needs to be started throug the Recorder window (in case the UI is reset go to Window -> General -> Recorder), adjust settings like output path and start recording. The RGB and depth maps will be save in the folder set in the Recorder Window settings, the segmentaion and instance masks will be save the in the Perception output folder, that is c:\Users\XXXX\AppData\LocalLow\ObjectRoom\ObjectRoom\XXXXXX folder

