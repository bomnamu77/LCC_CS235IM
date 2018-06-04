using System;
using UIKit;
using Foundation;
using System.Collections.Generic;
using System.Linq;

namespace Lab7
{
    // *********************** ProgrammingLangInfo class ***********************

    //public enum DwarfType { Disney, Tolkein, Marvel };



    public class ProgrammingLangInfo
    {
        public string Name { get; set; }
        public string Year { get; set; }
        public string ChiefDevelopers { get; set; }

        public string Predecessors { get; set; }
    }


    public class ProgrammingLangDataSource: UITableViewSource
    {

        //      ---------- Fields -----------
        const string CELL_IDENTIFIER = "programcell"; // set in the Storyboard
        string[] keys;
        ProgrammingLangTableViewController owner;

        // I Hard-coded the dwarf data to show the structure of the data in the 
        // dictionary. This is good as a teaching example, but not the 
        // most elegant way to do this.

        private Dictionary<string, List<ProgrammingLangInfo>> indexedTableItems =
            new Dictionary<string, List<ProgrammingLangInfo>>
        {
            {"A", new List<ProgrammingLangInfo>
                { new ProgrammingLangInfo{Name = "ARC Assembly", Year = "1947", ChiefDevelopers = "Kathleen Booth", Predecessors = "ENIAC coding system"},
                    new ProgrammingLangInfo{Name = "ALGAE", Year = "1951", ChiefDevelopers = "Edward A Voorhees and Karl Balke", Predecessors = "None"},
                    new ProgrammingLangInfo{Name = "ALGOL 58", Year = "1958", ChiefDevelopers = "Jean Ichbiah at CII Honeywell Bull", Predecessors = "Green"},
                    new ProgrammingLangInfo{Name = "APL", Year = "1962", ChiefDevelopers = "Kenneth E. Iverson", Predecessors = "None"},

                    new ProgrammingLangInfo{Name = "Ada 80", Year = "1980", ChiefDevelopers = "ACM/GAMM", Predecessors = "FORTRAN, IT, Sequentielle Formelübersetzung"}


                }
            },
            {"B", new List<ProgrammingLangInfo>
                { new ProgrammingLangInfo{Name = "BASIC", Year = "1964", ChiefDevelopers = "John George Kemeny and Thomas Eugene Kurtz at Dartmouth College", Predecessors= "FORTRAN II, JOSS"},
                    new ProgrammingLangInfo{Name = "BLISS", Year = "1970", ChiefDevelopers = "Wulf, Russell, Habermann at Carnegie Mellon University", Predecessors= "ALGOL"},
                    new ProgrammingLangInfo{Name = "Borland Delphi", Year = "1995", ChiefDevelopers = "Anders Hejlsberg at Borland", Predecessors= "Borland Pascal"},
                    new ProgrammingLangInfo{Name = "Boo", Year = "2003", ChiefDevelopers = "Rodrigo B. de Oliveira", Predecessors= "Python, C#"}
                }
            },

            {"C", new List<ProgrammingLangInfo>
                { new ProgrammingLangInfo{Name = "COMPOOL", Year = "1952", ChiefDevelopers = "RAND/SDC", Predecessors= "none"},
                    new ProgrammingLangInfo{Name = "COMTRAN", Year = "1957", ChiefDevelopers = "Bob Bemer", Predecessors= "FLOW-MATIC"},
                    new ProgrammingLangInfo{Name = "COBOL", Year = "1959", ChiefDevelopers = "The CODASYL Committee", Predecessors= "FLOW-MATIC, COMTRAN, FACT"},
                    new ProgrammingLangInfo{Name = "C", Year = "1972", ChiefDevelopers = "Dennis Ritchie", Predecessors= "B, BCPL, ALGOL 68"},
                    new ProgrammingLangInfo{Name = "C++", Year = "1983", ChiefDevelopers = "Bjarne Stroustrup", Predecessors= "C with Classes"},
                    new ProgrammingLangInfo{Name = "CLIPPER", Year = "1984", ChiefDevelopers = "Nantucket", Predecessors= "dBase"},
                    new ProgrammingLangInfo{Name = "C#", Year = "2000", ChiefDevelopers = "Anders Hejlsberg, Microsoft (ECMA)", Predecessors= "C, C++, Java, Delphi, Modula-2"}

                }
            },

            {"F", new List<ProgrammingLangInfo>
                { new ProgrammingLangInfo{Name = "Fortran", Year = "1954–55", ChiefDevelopers = "Team led by John W. Backus at IBM", Predecessors= "Speedcoding"},
                    new ProgrammingLangInfo{Name = "FACT", Year = "1959", ChiefDevelopers = "Fletcher R. Jones, Roy Nutt, Robert L. Patrick", Predecessors= "None"},
                    new ProgrammingLangInfo{Name = "Forth", Year = "1968", ChiefDevelopers = "Moore", Predecessors= "None"}
                }
            },


            {"J", new List<ProgrammingLangInfo>
                { new ProgrammingLangInfo{Name = "JOVIAL", Year = "1959", ChiefDevelopers = "Jules Schwartz at SDC", Predecessors= "ALGOL 58"},
                    new ProgrammingLangInfo{Name = "Java", Year = "1995", ChiefDevelopers = "James Gosling at Sun Microsystems", Predecessors= "C, Simula 67, C++, Smalltalk, Ada 83, Objective-C, Mesa"},
                    new ProgrammingLangInfo{Name = "JavaScript", Year = "1995", ChiefDevelopers = "Brendan Eich at Netscape", Predecessors= "LiveScript"}
                }
            },

            {"L", new List<ProgrammingLangInfo>
                { new ProgrammingLangInfo{Name = "LISP", Year = "1956–58", ChiefDevelopers = "John McCarthy", Predecessors= "IPL"},
                    new ProgrammingLangInfo{Name = "LIS", Year = "1973", ChiefDevelopers = "Jean Ichbiah et al. at CII Honeywell Bull", Predecessors= "Pascal, Sue"},
                    new ProgrammingLangInfo{Name = "LPC", Year = "1989", ChiefDevelopers = "Lars Pensjö", Predecessors= "None"},
                    new ProgrammingLangInfo{Name = "Lua", Year = "1993", ChiefDevelopers = "Roberto Ierusalimschy et al. at Tecgraf, PUC-Rio", Predecessors= "Scheme, SNOBOL, Modula, CLU, C++"},
                    new ProgrammingLangInfo{Name = "Lasso", Year = "1996", ChiefDevelopers = "Blue World Communications Inc.", Predecessors= "None"},

                }
            },

            {"P", new List<ProgrammingLangInfo>
                { new ProgrammingLangInfo{Name = "Pascal", Year = "1959", ChiefDevelopers = "The CODASYL Committee", Predecessors= "FLOW-MATIC, COMTRAN, FACT"},
                    new ProgrammingLangInfo{Name = "PL/I", Year = "1964", ChiefDevelopers = "IBM", Predecessors= "ALGOL 60, COBOL, FORTRAN"},

                    new ProgrammingLangInfo{Name = "Python", Year = "1972", ChiefDevelopers = "Dennis Ritchie", Predecessors= "B, BCPL, ALGOL 68"},
                    new ProgrammingLangInfo{Name = "PostScript", Year = "1982", ChiefDevelopers = "Warnock", Predecessors= "InterPress"},

                    new ProgrammingLangInfo{Name = "PHP", Year = "1983", ChiefDevelopers = "Bjarne Stroustrup", Predecessors= "C with Classes"},
                    new ProgrammingLangInfo{Name = "Perl", Year = "1987", ChiefDevelopers = "Larry Wall", Predecessors= "C, sed, awk, sh"}
                }
            },

            {"R", new List<ProgrammingLangInfo>
                { new ProgrammingLangInfo{Name = "RAPT", Year = "1978", ChiefDevelopers = "Pat Ambler and Robin Popplestone", Predecessors= "APT"},

                    new ProgrammingLangInfo{Name = "REXX", Year = "1979", ChiefDevelopers = "Mike Cowlishaw at IBM", Predecessors= "PL/I, BASIC, EXEC 2"},
                    new ProgrammingLangInfo{Name = "RPL", Year = "1984", ChiefDevelopers = "Hewlett-Packard", Predecessors= "Forth, Lisp"},
                    new ProgrammingLangInfo{Name = "Ruby", Year = "1995", ChiefDevelopers = "Yukihiro Matsumoto", Predecessors= "Smalltalk, Perl"},
                    new ProgrammingLangInfo{Name = "Racket", Year = "1995", ChiefDevelopers = "Matthew Flatt at Rice University", Predecessors= "Scheme, Lisp"}
                }
            },

            {"S", new List<ProgrammingLangInfo>
                { new ProgrammingLangInfo{Name = "Speedcoding", Year = "1953", ChiefDevelopers = "John W. Backus", Predecessors= "none"},
                    new ProgrammingLangInfo{Name = "SNOBOL", Year = "1962", ChiefDevelopers = "Ralph Griswold, et al.", Predecessors= "FORTRAN II, COMIT"},
                    new ProgrammingLangInfo{Name = "Simula", Year = "1962", ChiefDevelopers = "...", Predecessors= "ALGOL 60"},
                    new ProgrammingLangInfo{Name = "Smalltalk", Year = "1972", ChiefDevelopers = "Alan Kay, Adele Goldberg, Dan Ingalls, Xerox PARC", Predecessors= "Simula 67"},
                    new ProgrammingLangInfo{Name = "Scheme", Year = "1975", ChiefDevelopers = "Gerald Jay Sussman, Guy L. Steele, Jr.", Predecessors= "LISP"},
                    new ProgrammingLangInfo{Name = "SPARK", Year = "1988", ChiefDevelopers = "Bernard A. Carré", Predecessors= "Ada"},
                    new ProgrammingLangInfo{Name = "Scratch", Year = "2001", ChiefDevelopers = "Mitchel Resnick, John Maloney, Natalie Rusk, Evelyn Eastmond, Tammy Stern, Amon Millner, Jay Silver, and Brian Silverman", Predecessors= "Logo, Smalltalk, Squeak, E-Toys, HyperCard, AgentSheets, StarLogo, Tweak, BYOB"},
                    new ProgrammingLangInfo{Name = "Swift", Year = "2014", ChiefDevelopers = "Apple Inc.", Predecessors= "Objective-C, Rust, Haskell, Ruby, Python, C#, CLU"}
                }
            },
            {"T", new List<ProgrammingLangInfo>
                    { new ProgrammingLangInfo{Name = "TRAC", Year = "1959", ChiefDevelopers = "Calvin Mooers", Predecessors= "none"},
                        new ProgrammingLangInfo{Name = "TELCOMP", Year = "1965", ChiefDevelopers = "BBN", Predecessors= "JOSS"},
                        new ProgrammingLangInfo{Name = "TTM ", Year = "1968", ChiefDevelopers = "Steven Caine and E. Kent Gordon, California Institute of Technology", Predecessors= "GAP, GPM"},
                        new ProgrammingLangInfo{Name = "Turing", Year = "1982", ChiefDevelopers = "Ric Holt and James Cordy, at University of Toronto", Predecessors= "Euclid"},
                        new ProgrammingLangInfo{Name = "Tcl", Year = "1988", ChiefDevelopers = "John Ousterhout", Predecessors= "Awk, Lisp"},
                        new ProgrammingLangInfo{Name = "Tea", Year = "1997", ChiefDevelopers = "Jorge Nunes", Predecessors= "Java, Scheme, Tcl"}
                }
            }
        };
    

        //   ---------- Constructor ---------- 

        public ProgrammingLangDataSource(ProgrammingLangTableViewController owner)
        {
            keys = indexedTableItems.Keys.ToArray();
            this.owner = owner;
        }



        //          --------- Methods ----------
        public ProgrammingLangInfo GetProgrammingLangInfo(int section, int row)
        {
            return indexedTableItems[keys[section]][row];
        }


        //    ---------- base class overrides ----------
        public override nint NumberOfSections(UITableView tableView)
        {
            return keys.Length;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return indexedTableItems[keys[section]].Count;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            // in a Storyboard, Dequeue will ALWAYS return a cell, 
            var cell = tableView.DequeueReusableCell(CELL_IDENTIFIER);
            // now set the properties as normal
            //if (cell == null)
            
                //cell = new UITableViewCell(UITableViewCellStyle.Default, CELL_IDENTIFIER); 
            
            cell.TextLabel.Text = GetProgrammingLangInfo(indexPath.Section, indexPath.Row).Name + ", " + GetProgrammingLangInfo(indexPath.Section, indexPath.Row).Year;

            return cell;
        }

        /*
        /// <summary>
        /// Called when a row is touched
        /// </summary>
        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            string name = GetProgrammingLangInfo(indexPath.Section, indexPath.Row).Name;
            string chiefDeveloper = "• Chief Developer: "+GetProgrammingLangInfo(indexPath.Section, indexPath.Row).ChiefDevelopers;
            string predecessors = "• Predecessors: "+GetProgrammingLangInfo(indexPath.Section, indexPath.Row).Predecessors;
            UIAlertController okAlertController = UIAlertController.Create(name, chiefDeveloper+"\n"+predecessors, UIAlertControllerStyle.ActionSheet);
            okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));

            owner.PresentViewController(okAlertController, true, null);

            tableView.DeselectRow(indexPath, true);
        }
        */
        public override string[] SectionIndexTitles(UITableView tableView)
        {
            return keys;
        }
    }
}
