using System;
using System.Collections.Generic;

namespace ParseTheParcel
{
	public class ParcelAdvisor
	{
		/* 
		 * Responsible for advising customer of type of package solution and cost of
		 *  that solution, given dimensions and weight as input
		 * Returns meaningful error message where dimensions and/or weight do not conform
		 *   to business rules
		 */

		// Business rules
		//public enum PackageTypes { Small, Medium, Large, Oversize, Overweight };
		private Dictionary <int, string> packageCosts;
		private Dictionary <int, Array> acceptableDimensions;

		private double maxWeight;

		public ParcelAdvisor ()
		{
			//initialise business rules data 

			maxWeight = 25.0;

			packageCosts = new Dictionary <int, string> ();
			packageCosts.Add ((int)PackageTypes.Small, "$5.00");
			packageCosts.Add ((int)PackageTypes.Medium, "$7.50");
			packageCosts.Add ((int)PackageTypes.Large, "$8.50");

			acceptableDimensions = new Dictionary<int, Array> ();
			int[] smallDimensions = {200, 300, 150};
			acceptableDimensions.Add ((int)PackageTypes.Small, smallDimensions);
			int[] mediumDimensions = {300, 400, 200};
			acceptableDimensions.Add ((int)PackageTypes.Medium, mediumDimensions);
			int[] largeDimensions = {400, 600, 250};
			acceptableDimensions.Add ((int)PackageTypes.Large, largeDimensions);
		}

		public int getPackageSolution (int length, int breadth, int height, double weight) {
			/*
			 * Inputing the dimensions presents potential v. poor usability: users
			 * should not need to have to figure out how to match input to our internal
			 * rules via  repeated error messages. e.g. the longest dimension is 'breadth' 
			 * 
			 * Code the algorithm to accept correct dimension sets where 'length',
			 * 'breadth', 'height' are all interchangeable.			 
			 */

			// check weight & early return if overweight
			if(weight > maxWeight) { return (int) PackageTypes.Overweight; }
			
			// check dimensions
			int result= -1;
			int[] dimensions = {length, breadth, height};
			dimensions = Array.Sort(dimensions);
			dimensions = Array.Reverse (dimensions);

			int largestDimension = dimensions[0];
			int middleDimension = dimensions[1]; 
			int smallestDimension = dimensions[2];

			int largeBreadthMax = getAcceptableDimension((int)PackageTypes.Large, (int) DimensionNames.breadth);
			int largeLengthMax = getAcceptableDimension((int)PackageTypes.Large, (int) DimensionNames.length);
			int largeHeightMax = getAcceptableDimension((int)PackageTypes.Large, (int) DimensionNames.height);

			int mediumBreadthMax = getAcceptableDimension((int)PackageTypes.Medium, (int) DimensionNames.breadth);
			int mediumLengthMax = getAcceptableDimension((int)PackageTypes.Medium, (int) DimensionNames.length);
			int mediumHeightMax = getAcceptableDimension((int)PackageTypes.Medium, (int) DimensionNames.height);

			int smallBreadthMax = getAcceptableDimension((int)PackageTypes.Small, (int) DimensionNames.breadth);
			int smallLengthMax = getAcceptableDimension((int)PackageTypes.Small, (int) DimensionNames.length);
			int smallHeightMax = getAcceptableDimension((int)PackageTypes.Small, (int) DimensionNames.height);

			//Filter via largest supplied dimension
			if (largestDimension > largeBreadthMax) {
				result = (int)PackageTypes.Oversize;
			} else if ((largestDimension <= largeBreadthMax) && (largestDimension > mediumBreadthMax)) {
				result = (int)PackageTypes.Large;
			} else {
				result = (int) PackageTypes.Overweight; //FAIL
			}
			//verify next largest dimension ok or oversize
			//verify smallest dimension ok or oversize
			//assign type
			//return type
			return result;

		}

		private int getAcceptableDimension(int type_index, int dimension_index) {
			//dimension_index: 0 = length, 1 = breadth, 2 = height
			int[] dimensions = (int[])acceptableDimensions[type_index];
			return dimensions [dimension_index];
		}

		public void writeAdvice (int packageSolution) {
			switch (packageSolution) {
			case (int) PackageTypes.Small:
				Console.WriteLine ("Package conforms to Small constraints - cost is " +
					packageCosts [packageSolution]);
				break;

			case (int) PackageTypes.Medium:
				Console.WriteLine ("Package conforms to Medium constraints - cost is " +
					packageCosts [packageSolution]);
				break;

			case (int) PackageTypes.Large:
				Console.WriteLine ("Package conforms to Large constraints - cost is " +
					packageCosts [packageSolution]);
				break;

			case (int) PackageTypes.Oversize:
				Console.WriteLine ("Package dimensions are too large for this service");
				break;

			case (int) PackageTypes.Overweight:
				Console.WriteLine ("Package is over maximum weight for this service");
				break;

			default:
				Console.WriteLine ("This statement should NOT be reached");
				break;
			}
		}
	}
}

