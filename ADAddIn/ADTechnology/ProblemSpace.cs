﻿using EAAddInFramework.MDGBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Color = System.Drawing.Color;

namespace AdAddIn.ADTechnology
{
    public static class ProblemSpace
    {
        public static readonly IEnumerable<ITaggedValue> ProblemSpaceTaggedValues = new[]{
            Common.OwnerRole,
            Common.StakeholderRoles,
            Common.ProjectStage,
            Common.Viewpoint,
            Common.OrganisationalReach,
            Common.IntellectualPropertyRights
        };

        public static readonly ElementStereotype Problem = new ElementStereotype(
            name: "adProblem",
            displayName: "Problem",
            type: ElementType.Class,
            instanceType: SolutionSpace.ProblemOccurrence,
            icon: new Icon("AdAddIn.ADTechnology.Problem.bmp"),
            shapeScript: @"
                shape main{
	                h_align = ""center"";
	                v_align = ""center"";

	                StartPath();
	                MoveTo(50,0);
	                LineTo(100,50);
	                LineTo(50,100);
	                LineTo(0,50);
	                EndPath();
	                FillAndStrokePath();
	
	                Println(""#NAME#"");
                }
            ",
            width: 100,
            height: 70,
            backgroundColor: Color.LightSkyBlue,
            taggedValues: ProblemSpaceTaggedValues);

        public static readonly ElementStereotype Option = new ElementStereotype(
            name: "adOption",
            displayName: "Option",
            type: ElementType.Class,
            instanceType: SolutionSpace.OptionOccurrence,
            icon: new Icon("AdAddIn.ADTechnology.Option.bmp"),
            shapeScript: @"
                shape main{
	                h_align = ""center"";
	                v_align = ""center"";

	                roundrect(0,0,100,100,30,30);

	                Print(""#name#"");
                }
            ",
            width: 100,
            height: 70,
            backgroundColor: Color.LightYellow,
            taggedValues: ProblemSpaceTaggedValues);
    }
}
