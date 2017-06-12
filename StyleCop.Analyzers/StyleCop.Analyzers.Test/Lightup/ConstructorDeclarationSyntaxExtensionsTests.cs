﻿// Copyright (c) Tunnel Vision Laboratories, LLC. All Rights Reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace StyleCop.Analyzers.Test.Lightup
{
    using System;
    using Microsoft.CodeAnalysis.CSharp;
    using StyleCop.Analyzers.Lightup;
    using Xunit;

    public class ConstructorDeclarationSyntaxExtensionsTests
    {
        [Fact]
        public void TestWithExpressionBody()
        {
            var syntax = SyntaxFactory.ConstructorDeclaration(SyntaxFactory.Identifier("Anything"));

            // With default value is allowed
            var syntaxWithDefaultBody = ConstructorDeclarationSyntaxExtensions.WithExpressionBody(syntax, null);
            Assert.Null(BaseMethodDeclarationSyntaxExtensions.ExpressionBody(syntaxWithDefaultBody));

            // Non-default throws an exception
            var expressionBody = SyntaxFactory.ArrowExpressionClause(SyntaxFactory.LiteralExpression(SyntaxKind.NullLiteralExpression));
            Assert.Throws<NotSupportedException>(() => ConstructorDeclarationSyntaxExtensions.WithExpressionBody(syntax, expressionBody));
        }
    }
}