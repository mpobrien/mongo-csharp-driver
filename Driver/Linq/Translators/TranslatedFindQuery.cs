﻿/* Copyright 2010-2012 10gen Inc.
*
* Licensed under the Apache License, Version 2.0 (the "License");
* you may not use this file except in compliance with the License.
* You may obtain a copy of the License at
*
* http://www.apache.org/licenses/LICENSE-2.0
*
* Unless required by applicable law or agreed to in writing, software
* distributed under the License is distributed on an "AS IS" BASIS,
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
* See the License for the specific language governing permissions and
* limitations under the License.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;

namespace MongoDB.Driver.Linq
{
    /// <summary>
    /// Represents a LINQ query that has been translated to an equivalent MongoDB Find query.
    /// </summary>
    public class TranslatedFindQuery : TranslatedQuery
    {
        // private fields
        private IMongoQuery _query;
        private Type _documentType;

        // constructor
        /// <summary>
        /// Initializes a new instance of the MongoLinqFindQuery class.
        /// </summary>
        /// <param name="collection">The collection being queried.</param>
        /// <param name="query">The query.</param>
        /// <param name="documentType">The document type.</param>
        public TranslatedFindQuery(MongoCollection collection, IMongoQuery query, Type documentType)
            : base(collection)
        {
            _query = query;
            _documentType = documentType;
        }

        // public methods
        /// <summary>
        /// Executes the translated Find query.
        /// </summary>
        /// <returns>The result of executing the translated Find query.</returns>
        public override object Execute()
        {
            var cursor = _collection.FindAs(_documentType, _query);
            // TODO: modify the cursor with things like sort order, skip and limit
            return cursor;
        }
    }
}
