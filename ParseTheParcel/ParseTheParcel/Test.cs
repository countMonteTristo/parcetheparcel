using NUnit.Framework;
using System;

namespace ParseTheParcel
{

	[TestFixture ()]
	public class Test
	{
		/* The assumption is made that input type validation has already been
		 * performed: i.e. safe to expect (int, int, int, double) only as args 
		 * to getPackageSoloution, and no zero or negative values
		 */
			
		ParcelAdvisor advisor;

		[TestFixtureSetUp]
		public void SetUp() {
		    advisor = new ParcelAdvisor ();
		}

		[Test ()]
		public void firstTest()
		{
			int result = advisor.getPackageSolution (2, 3, 1, 1.0);
			Assert.AreEqual((int) PackageTypes.Oversize, result);
			advisor.writeAdvice (result);
		}

		//Test Nominal case: small package, parameters ordered as per specifications

		//Test Nominal case: medium package, parameters ordered as per specifications

		//Test Nominal case: large package, parameters ordered as per specifications

		//Test Nominal case: small package, parameters NOT ordered to spec, but valid

		//Test Nominal case: medium package, parameters NOT ordered to spec, but valid

		//Test Nominal case: large package, parameters NOT ordered to spec, but valid

		//Test nominal except overweight

		/*** Edge cases *****/

		// Test Nominal dimensions, weight = 25.0
		// Test Nominal dimensions, weight = 24.9
		// Test Nominal dimensions, weight = 25.1


		// Two dimensions within bounds but not conforming to specs (hard to explain):
		// dimensions 500, 500, 200 - should return Oversize

		// As above but for medium bounds - should return Large
		// dimensions 350, 350, 150

		// As above but for small bounds - should return Medium
		// dimensions 250, 250, 100

		// Test accept 1mm x 1mm x 1mm package - require another business rule?

		//Test dimensions at Small max 200 x 300 x 150 -should return Small
		//Test dimensions over Small max 400 x 600 x 251 -should return Medium

		//Test dimensions at Medium max 300 x 400 x 200 -should return Medium
		//Test dimensions over Medium max 300 x 400 x 201 -should return Large

		//Test dimensions at Large max 400 x 600 x 250 -should return Large
		//Test dimensions over Large max 400 x 600 x 251 -should return Oversize

	}
}



