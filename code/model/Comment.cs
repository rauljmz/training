using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Training.framework;

namespace Training.code.model
{
    [Template("{F82E865B-3262-48D2-849F-05CCB45DA9D5}")]
    public class Comment
    {

        public Field<string> Author { get; set; }

        [Field("Text")]
        public Field<string> CommentText { get; set; }


        public Field<Link> Link { get; set; }
    }
}