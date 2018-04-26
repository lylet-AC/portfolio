package Lab2;

import lejos.hardware.Button;
import lejos.hardware.Sound;
import lejos.hardware.motor.Motor;
import lejos.hardware.port.SensorPort;
import lejos.hardware.sensor.EV3ColorSensor;
import lejos.hardware.sensor.EV3UltrasonicSensor;
import lejos.robotics.RegulatedMotor;
import lejos.robotics.SampleProvider;
import lejos.robotics.navigation.DifferentialPilot;
import lejos.utility.Delay;
import lejos.utility.PilotProps;

public class Balloon_Maze_Alpha {

	public static void main(String[] args) {
		
		//Color Sensor Setup
		EV3ColorSensor colorSensor = new EV3ColorSensor(SensorPort.S2);
		SampleProvider colorSamplePr = colorSensor.getRedMode();
		float[] colorSample = new float[colorSamplePr.sampleSize()];
		
		/* To use color sensor <colorSamplePr.fetchSample(colorSample, 0);> */

		//Sonic Sensor Setup
		EV3UltrasonicSensor sonicSensor = new EV3UltrasonicSensor(SensorPort.S1);
		SampleProvider sonicSamplePr = sonicSensor.getDistanceMode();
		float[] sonicSample = new float[sonicSamplePr.sampleSize()];
		
		/* To use sonic sensor <sonicSamplePr.fetchSample(sonicSample, 0);> */
		
		//left and right wheel motors
		PilotProps p= new PilotProps();
		RegulatedMotor leftMotor = PilotProps.getMotor(p.getProperty(PilotProps.KEY_LEFTMOTOR, "B"));
		System.out.println("Motor B is working");
		RegulatedMotor rightMotor = PilotProps.getMotor(p.getProperty(PilotProps.KEY_RIGHTMOTOR, "C"));
		System.out.println("Motor C is working");
    	float TYRE_DIAMETER = 5.6f;
    	final float AXLE_TRACK = 9.7f;
		final DifferentialPilot pilot = new DifferentialPilot(TYRE_DIAMETER, AXLE_TRACK, leftMotor, rightMotor);
		pilot.setAcceleration(30);

		//START::DASH
		System.out.println("Hit any button to START::DASH");
		Button.waitForAnyPress();
		
		boolean didITurn360 = false;
		double degrees = 0;
		int tempDistance = 0;
		

		while (didITurn360 != true) {
			
			//fetches distance to object
			sonicSamplePr.fetchSample(sonicSample, 0);
			
			//travels to object if it's within .5 meters
			if (sonicSample[0] <= .45) {
				
				System.out.println("I see an object!");
				Sound.beep();
				Delay.msDelay(60);
				
				//rotates to correct the angle of the sonic sensor
				pilot.rotate(16);
				degrees +=16;
				Delay.msDelay(30);
				
				//travels to object
				pilot.travel(-(((sonicSample[0])*100)-2));
				Sound.buzz();
				tempDistance += (((sonicSample[0])*100)-1);
				System.out.println("Traveling to object.");
				Delay.msDelay(300);
				
				
				//fetches distance to object
				/*sonicSamplePr.fetchSample(sonicSample, 0);
				
				if (sonicSample[0] >= .02) {
				
					pilot.travel(-((sonicSample[0])*100)-2);
					Sound.buzz();
					tempDistance += ((sonicSample[0])*100);
					System.out.println("Traveling to object.");
					
				}*/
				
				//fetches color sample
				colorSamplePr.fetchSample(colorSample, 0);
				
				//pop balloon if red value is higher than .12
				if(colorSample[0]>=.09) {
					System.out.println("Found a red ballon!");
					Sound.beepSequenceUp();
					Motor.A.setAcceleration(50000);
					Motor.A.rotate(270);
					Delay.msDelay(30);
					Motor.A.rotate(-280);
					
					//laughs at the destroyed balloon
					Delay.msDelay(50);
					Sound.buzz();
					Delay.msDelay(50);
					Sound.buzz();
					Delay.msDelay(50);
					Sound.buzz();
					Delay.msDelay(50);
				}
				
				else {
					System.out.println("Found a black balloon.");
					Sound.beepSequence();
					Delay.msDelay(30);
				}
				
				//backs up to keep checking for balloon
				pilot.travel(tempDistance);
				tempDistance = 0;
				Delay.msDelay(30);
				System.out.println("Backing up...");
				
				pilot.rotate(30);
				degrees+=30;
			}	
			
			if (degrees >= 420) {
				didITurn360 = true;
			}
			
			//rotates to try to find a balloon
			pilot.rotate(4);
			degrees +=4;
			Delay.msDelay(30);
		}
		
		System.out.println("Balloon Fight Complete");
		Sound.beepSequenceUp();
		
		
	}

}
