import React from "react";
import Webcam from "react-webcam";

import Button from "components/CustomButtons/Button.js";

const videoConstraints = {
    width: 320,
    height: 240,
    facingMode: "user"
  };
   
  export default function WebcamCapture() {
    const webcamRef = React.useRef(null);
   
    const capture = React.useCallback(
      () => {
        const imageSrc = webcamRef.current.getScreenshot();
      },
      [webcamRef]
    );
   
    return (
      <>
        <Webcam
          audio={false}
          height={240}
          ref={webcamRef}
          screenshotFormat="image/jpeg"
          width={320}
          videoConstraints={videoConstraints}
        />
         <Button color="primary" round onClick={capture}>
         Capture photo
                </Button> 
         
      </>
    );
  };