﻿using System;
using System.Collections.Generic;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;

namespace Retro.Web.Security
{
    public class IdentityUser : IUser
    {
        public IdentityUser() {
            Claims = new List<IdentityUserClaim>();
            Roles = new List<string>();
            Logins = new List<UserLoginInfo>();
            Retrospectives = new List<RetrospectiveLocation>();
        }

        public IdentityUser(string userName) : this() {
            UserName = userName;
        }

        /// <summary>
        ///     Email
        /// </summary>
        public virtual string Email { get; set; }

        /// <summary>
        ///     True if the email is confirmed, default is false
        /// </summary>
        public virtual bool EmailConfirmed { get; set; }

        /// <summary>
        ///     The salted/hashed form of the user password
        /// </summary>
        public virtual string PasswordHash { get; set; }

        /// <summary>
        ///     A random value that should change whenever a users credentials change (password changed, login removed)
        /// </summary>
        public virtual string SecurityStamp { get; set; }

        /// <summary>
        ///     PhoneNumber for the user
        /// </summary>
        public virtual string PhoneNumber { get; set; }

        /// <summary>
        ///     True if the phone number is confirmed, default is false
        /// </summary>
        public virtual bool PhoneNumberConfirmed { get; set; }

        /// <summary>
        ///     Is two factor enabled for the user
        /// </summary>
        public virtual bool TwoFactorEnabled { get; set; }

        /// <summary>
        ///     DateTime in UTC when lockout ends, any time in the past is considered not locked out.
        /// </summary>
        public virtual DateTimeOffset LockoutEnd { get; set; }

        /// <summary>
        ///     Is lockout enabled for this user
        /// </summary>
        public virtual bool LockoutEnabled { get; set; }

        /// <summary>
        ///     Used to record failures for the purposes of lockout
        /// </summary>
        public virtual int AccessFailedCount { get; set; }

        /// <summary>
        ///     Gets the logins.
        /// </summary>
        /// <value>The logins.</value>
        public virtual IList<UserLoginInfo> Logins { get; private set; }

        /// <summary>
        ///     Gets the claims.
        /// </summary>
        /// <value>The claims.</value>
        public virtual IList<IdentityUserClaim> Claims { get; private set; }

        /// <summary>
        ///     Gets the roles.
        /// </summary>
        /// <value>The roles.</value>
        public virtual IList<string> Roles { get; private set; }

        public IList<RetrospectiveLocation> Retrospectives { get; set; }

        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        public string UserName { get; set; }
    }

    public class RetrospectiveLocation
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "createdOn")]
        public DateTime CreatedOn { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
    }


    /// <summary>
    ///     Class IdentityUserClaim.
    /// </summary>
    public class IdentityUserClaim
    {
        /// <summary>
        ///     Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public virtual string Id { get; set; }

        /// <summary>
        ///     Gets or sets the user identifier.
        /// </summary>
        /// <value>The user identifier.</value>
        public virtual string UserId { get; set; }

        /// <summary>
        ///     Gets or sets the type of the claim.
        /// </summary>
        /// <value>The type of the claim.</value>
        public virtual string ClaimType { get; set; }

        /// <summary>
        ///     Gets or sets the claim value.
        /// </summary>
        /// <value>The claim value.</value>
        public virtual string ClaimValue { get; set; }
    }
}