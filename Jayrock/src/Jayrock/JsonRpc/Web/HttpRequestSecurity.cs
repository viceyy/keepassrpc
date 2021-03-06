#region License, Terms and Conditions
//
// Jayrock - JSON and JSON-RPC for Microsoft .NET Framework and Mono
// Written by Atif Aziz (www.raboof.com)
// Copyright (c) 2005 Atif Aziz. All rights reserved.
//
// This library is free software; you can redistribute it and/or modify it under
// the terms of the GNU Lesser General Public License as published by the Free
// Software Foundation; either version 3 of the License, or (at your option)
// any later version.
//
// This library is distributed in the hope that it will be useful, but WITHOUT
// ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS
// FOR A PARTICULAR PURPOSE. See the GNU Lesser General Public License for more
// details.
//
// You should have received a copy of the GNU Lesser General Public License
// along with this library; if not, write to the Free Software Foundation, Inc.,
// 59 Temple Place, Suite 330, Boston, MA 02111-1307 USA 
//
#endregion

namespace Jayrock.JsonRpc.Web
{
    #region Imports

    using System;
    using System.Web;

    #endregion

    /// <summary>
    /// Helper methods for security web requests.
    /// </summary>

    public sealed class HttpRequestSecurity
    {
        public static bool IsLocal(HttpRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("request");

            //
            // NOTE: In ASP.NET 2.0, one can simply use IsLocal on HttpRequest.
            //

            string userHostAddress = Mask.NullString(request.UserHostAddress);
            
            return userHostAddress.Equals("127.0.0.1") /* IP v4 */ || 
                userHostAddress.Equals("::1") /* IP v6 */ ||
                userHostAddress.Equals(request.ServerVariables["LOCAL_ADDR"]);
        }

        private HttpRequestSecurity()
        {
            throw new NotSupportedException();
        }
    }
}
